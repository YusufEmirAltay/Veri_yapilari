using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class LessonController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Lessons.ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult LessonAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult LessonAdd(Lesson l)
		{
			Context.Lessons.Add(l);
			Context.SaveChanges();
			return RedirectToAction("Index", "Lesson");
		}
		public IActionResult LessonDelete(int id)
		{
			var d = Context.Lessons.Find(id);
			Context.Lessons.Remove(d);
			Context.SaveChanges();
			return RedirectToAction("Index", "Lesson");
		}
		public IActionResult LessonGet(int id)
		{
			var e = Context.Lessons.Find(id);
			return View("LessonGet", e);
		}
		public IActionResult LessonUpdate(Lesson l)
		{
			var r = Context.Lessons.Find(l.Lesson_Id);
			r.Lesson_Id = l.Lesson_Id;
			r.Name = l.Name;
			r.Status = l.Status;
			Context.SaveChanges();
			return RedirectToAction("Index", "Lesson");
		}
	}
}
