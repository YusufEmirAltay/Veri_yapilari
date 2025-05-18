using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class TeacherController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Lesson = Context.Lessons.ToList();
			var teachers = Context.Teachers.ToList();
			return View(teachers);
		}
		[HttpGet]
		public IActionResult TeacherAdd()
		{
			ViewBag.City = Context.Cities.ToList();
			ViewBag.Lessons = Context.Lessons.ToList();
			return View();
		}
		[HttpPost]
		public IActionResult TeacherAdd(entity.Concrate.Teacher t)
		{
			Context.Teachers.Add(t);
			Context.SaveChanges();
			return RedirectToAction("Index", "Teacher");
		}
		public IActionResult TeacherDelete(int id)
		{
			var silinecek = Context.Teachers.Find(id);
			Context.Teachers.Remove(silinecek);
			Context.SaveChanges();
			return RedirectToAction("Index", "Teacher");
		}
		public IActionResult TeacherGet(int id)
		{
			var adresses = Context.Adresses.Select(o => new
			{
				Adress_Id = o.Adress_Id,
				FullAdress = $"{o.Adress_Id}{") "}{o.City.Name}{" | "}{o.Town}{" | "}{o.Neighbourhood}{" Mahallesi | "}{o.Street}{" Sokak | Bina NO:"}{o.NO}{" | Kapı NO:"}{o.Apartment}"
			}).ToList();
			ViewBag.Addresses = new SelectList(adresses, "Adress_Id", "FullAdress");
			ViewBag.City = Context.Cities.ToList();
			ViewBag.Lessons = Context.Lessons.ToList();
			var getirilecek = Context.Teachers.Find(id);
			return View("TeacherGet", getirilecek);
		}
		public IActionResult TeacherUpdate(entity.Concrate.Teacher t)
		{
			var guncellenecek = Context.Teachers.Find(t.Teacher_Id);
			guncellenecek.Teacher_Id = t.Teacher_Id;
			guncellenecek.FirstName = t.FirstName;
			guncellenecek.LastName = t.LastName;
			guncellenecek.TC = t.TC;
			guncellenecek.BirthDay = t.BirthDay;
			guncellenecek.Phone = t.Phone;
			guncellenecek.Email = t.Email;
			guncellenecek.PreBio = t.PreBio;
			guncellenecek.DetailBio = t.DetailBio;
			guncellenecek.Status = t.Status;
			guncellenecek.Lesson_Id = t.Lesson_Id;
			Context.SaveChanges();
			return RedirectToAction("Index", "Teacher");
		}
	}
}
