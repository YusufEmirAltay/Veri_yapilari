using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Parent.Controllers
{
	[Area("Parent")]
	[Authorize(Roles = "PARENT")]
	public class StudentController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		Context Context = new Context();

		public StudentController(UserManager<AppUser> userManager, Context context)
		{
			_userManager = userManager;
			Context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			string TCS = values.UserName;
			long TCI = long.Parse(TCS);
			ViewBag.Parent = Context.Parents.Where(p => p.TC == TCI).ToList();

			var degerler=Context.Students.ToList();

			return View(degerler);
		}
	}
}
