using dto.dtos.AppUserDtos;
using entity.Concrate;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace web.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser
				{
					PhoneNumber = appUserRegisterDto.PhoneNumber,
					UserName = appUserRegisterDto.UserName,
					Email = appUserRegisterDto.Email,
					Name = appUserRegisterDto.Name,
					Surname = appUserRegisterDto.Surname,
				};
				var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
				if (result.Succeeded)
				{
					//kullanıcıya gönderilen e-posta
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Dershane", "o.hasan.41.41@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("Yeni Kullanıcı", appUser.Email);
					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);
					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Dershane sistemine kayıt başvurunuz başarıyla gerçekleşmiştir. Sistem yöenticimiz tarafından başvurunuz incelenecektir. Başvurunuzun onaylanması halinde sisteme giriş sağlayabileceksiniz.\nZeka Atölyesi Eğitim Kurumu\nTeşekkürler.";
					mimeMessage.Body = bodyBuilder.ToMessageBody();
					mimeMessage.Subject = "Dershane sistemine kayıt başvurusu.";

					//yöneticiye gönderilen e-posta
					MimeMessage mimeMessage2 = new MimeMessage();
					MailboxAddress mailboxAddressFrom2 = new MailboxAddress("Dershane", "o.hasan.41.41@gmail.com");
					MailboxAddress mailboxAddressTo2 = new MailboxAddress("Yönetici", "omerhasangulsoy@hotmail.com");
					mimeMessage2.From.Add(mailboxAddressFrom2);
					mimeMessage2.To.Add(mailboxAddressTo2);
					var bodyBuilder2 = new BodyBuilder();
					bodyBuilder2.TextBody = "Dershane sistemine yeni bir kayıt eklendi. Kişiyi görüntülemek, yetki vermek, onaylamak için bağlantıya gidin. https://localhost:44356/Login/Index";
					mimeMessage2.Body = bodyBuilder2.ToMessageBody();
					mimeMessage2.Subject = "Dershane sistemine yeni kayıt eklendi.";

					//gönderim işlemi sağlayıcısı
					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com", 587, false);
					client.Authenticate("o.hasan.41.41@gmail.com", "mnkvwyooiduvxbdt");
					client.Send(mimeMessage);
					client.Send(mimeMessage2);
					client.Disconnect(true);

					return RedirectToAction("Index", "Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View();
		}
	}
}
