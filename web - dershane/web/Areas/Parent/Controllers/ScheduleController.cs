using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Parent.Controllers
{
	[Area("Parent")]
	[Authorize(Roles = "PARENT")]
	public class ScheduleController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		Context Context = new Context();

		public ScheduleController(UserManager<AppUser> userManager, Context context)
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

			ViewBag.Student = Context.Students.ToList();
			ViewBag.Class = Context.Classes.ToList();
			ViewBag.Teacher = Context.Teachers.ToList();
			ViewBag.Lesson = Context.Lessons.ToList();

			DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
			DateTime endOfWeek = startOfWeek.AddDays(6);
			var degerler = Context.Schedules.Where(x => x.Time >= startOfWeek && x.Time <= endOfWeek).ToList();


			return View(degerler);
		}
	}
}
