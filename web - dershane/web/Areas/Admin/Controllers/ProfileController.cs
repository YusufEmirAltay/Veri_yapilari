using dto.dtos.AppUserDtos;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserEditDto appUserEditDto = new AppUserEditDto();
			appUserEditDto.Name = values.Name;
			appUserEditDto.Surname = values.Surname;
			appUserEditDto.UserName = values.UserName;
			return View(appUserEditDto);
		}
		[HttpPost]
		public async Task<IActionResult> Insex(AppUserEditDto appUserEditDto)
		{
			if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
			{
				var user = await _userManager.FindByEmailAsync(User.Identity.Name);
				user.Name = appUserEditDto.Name;
				user.Surname = appUserEditDto.Surname;
				user.UserName = appUserEditDto.UserName;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}
	}
}
