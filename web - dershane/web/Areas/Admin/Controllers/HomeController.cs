using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Workplace()
		{
			return View();
		}
		[HttpGet]
		public IActionResult System()
		{
			return View();
		}
		[HttpGet]
		public IActionResult User()
		{
			return View();
		}
    }
}
