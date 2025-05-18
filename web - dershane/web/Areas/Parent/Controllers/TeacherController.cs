using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Parent.Controllers
{
	[Area("Parent")]
	[Authorize(Roles = "PARENT")]
	public class TeacherController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Lesson = Context.Lessons.ToList();
			var degerler = Context.Teachers.Where(x => x.Status == true).ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult Details(int id)
		{
			ViewBag.Comment = Context.Blogs.Where(x => x.BlogPost_Id == id).ToList();
			ViewBag.Lesson = Context.Lessons.ToList();
			var e = Context.Teachers.Find(id);
			return View("Details", e);
		}
	}
}
