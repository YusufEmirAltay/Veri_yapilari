using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class HomeController : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{
			ViewBag.Blog = Context.Blogs.Where(x => x.Status == true).ToList();
			ViewBag.Testimonial = Context.Testimonials.Where(x => x.Status == true).ToList();
			ViewBag.Teacher = Context.Teachers.Where(x => x.Status == true).ToList();
			ViewBag.Lesson = Context.Lessons.ToList();
			return View();
		}
	}
}
