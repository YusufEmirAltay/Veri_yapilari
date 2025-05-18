using data.Concrate;
using dto.dtos.AppUserDtos;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace web.Areas.Teacher.Controllers
{
	[Area("Teacher")]
	[Authorize(Roles = "TEACHER")]

	public class UserController : Controller
	{
		Context Context = new Context();
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;

		public UserController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public UserController(Context context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			Context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public async Task<IActionResult> Profile()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserEditDto appUserEditDto = new AppUserEditDto();
			appUserEditDto.Name = values.Name;
			appUserEditDto.Surname = values.Surname;
			appUserEditDto.UserName = values.UserName;
			return View(appUserEditDto);
		}
		[HttpPost]
		public async Task<IActionResult> Profile(AppUserEditDto appUserEditDto)
		{
			if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
			{
				var user = await _userManager.FindByEmailAsync(User.Identity.Name);
				TempData["teacherTC"] = user.UserName.ToString();
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
