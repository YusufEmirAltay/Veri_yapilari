using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class ScheduleController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ScheduleCurrent()
		{
			DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
			DateTime endOfWeek = startOfWeek.AddDays(6);
			var degerler = Context.Schedules.Where(x => x.Time >= startOfWeek && x.Time <= endOfWeek).ToList();
			ViewBag.Teacher = Context.Teachers.ToList();
			ViewBag.Lesson = Context.Lessons.ToList();
			ViewBag.Class = Context.Classes.ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult ScheduleAdd()
		{
			var classes = Context.Classes.Select(c => new
			{
				Class_Id = c.Class_Id,
				NumberAndBranch = $"{c.Number} {c.Branch}"
			}).ToList();
			ViewBag.Class = new SelectList(classes, "Class_Id", "NumberAndBranch");
			var teachers = Context.Teachers.Select(t => new
			{
				Teacher_Id = t.Teacher_Id,
				FullName = $"{t.FirstName} {t.LastName}"
			}).ToList();
			ViewBag.Teacher = new SelectList(teachers, "Teacher_Id", "FullName");
			return View();
		}
		[HttpPost]
		public IActionResult ScheduleAdd(Schedule s)
		{
			Context.Schedules.Add(s);
			Context.SaveChanges();
			return RedirectToAction("ScheduleAdd", "Schedule");
		}
		public IActionResult ScheduleDelete(int id)
		{
			var silinecek = Context.Schedules.Find(id);
			Context.Schedules.Remove(silinecek);
			Context.SaveChanges();
			return RedirectToAction("Index", "Schedule");
		}
		public IActionResult ScheduleGet(int id)
		{

			var classes = Context.Classes.Select(c => new
			{
				Class_Id = c.Class_Id,
				NumberAndBranch = $"{c.Number} {c.Branch}"
			}).ToList();
			ViewBag.Class = new SelectList(classes, "Class_Id", "NumberAndBranch");

			var teachers = Context.Teachers.Select(t => new
			{
				Teacher_Id = t.Teacher_Id,
				FullName = $"{t.FirstName} {t.LastName}"
			}).ToList();
			ViewBag.Teacher = new SelectList(teachers, "Teacher_Id", "FullName");

			var getirilecek = Context.Schedules.Find(id);
			return View("ScheduleGet", getirilecek);
		}
		public IActionResult ScheduleUpdate(Schedule s)
		{
			var guncellenecek = Context.Schedules.Find(s.Schedule_Id);
			guncellenecek.Schedule_Id = s.Schedule_Id;
			guncellenecek.Time = s.Time;
			guncellenecek.Teacher_Id = s.Teacher_Id;
			guncellenecek.Class_Id = s.Class_Id;
			guncellenecek.Status = s.Status;
			Context.SaveChanges();
			return RedirectToAction("Index", "Schedule");
		}
	}
}
