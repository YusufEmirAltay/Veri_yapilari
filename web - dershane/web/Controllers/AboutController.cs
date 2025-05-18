using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class AboutController : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{

			ViewBag.Teacher = Context.Teachers.Where(x => x.Status == true).ToList();
			ViewBag.Lesson = Context.Lessons.ToList();
			return View();
		}
	}
}
