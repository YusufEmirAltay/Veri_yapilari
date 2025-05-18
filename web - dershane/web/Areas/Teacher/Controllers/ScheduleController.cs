using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Teacher.Controllers
{
	[Area("Teacher")]
	[Authorize(Roles = "TEACHER")]
	public class ScheduleController : Controller
	{
		Context Context = new Context();
		private readonly UserManager<AppUser> _userManager;

		public ScheduleController(Context context, UserManager<AppUser> userManager)
		{
			Context = context;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			string TCS = values.UserName;
			long TCI = long.Parse(TCS);
			ViewBag.Ogretmen = Context.Teachers.Where(s => s.TC == TCI).ToList();

			DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
			DateTime endOfWeek = startOfWeek.AddDays(6);
			var degerler = Context.Schedules.Where(x => x.Time >= startOfWeek && x.Time <= endOfWeek).ToList();


			return View(degerler);
		}
	}
}
