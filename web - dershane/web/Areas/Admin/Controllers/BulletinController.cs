using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class BulletinController : Controller
	{
		Context Context=new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Bulletin = Context.Subscribes.ToList();
			return View();
		}
	}
}
