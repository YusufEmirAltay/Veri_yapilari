using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class StudentController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Parents = Context.Parents.ToList();
			var degerler = Context.Students.ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult StudentAdd()
		{

			var parents = Context.Parents.Select(p => new
			{
				Parent_Id = p.Parent_Id,
				NameAndSurname = $"{p.FirstName} {p.LastName} {"|"} {"TC:"} {p.TC}"
			}).ToList();
			ViewBag.Parent = new SelectList(parents, "Parent_Id", "NameAndSurname");

			var classes = Context.Classes.Select(c => new
			{
				Class_Id = c.Class_Id,
				NumberAndBranch = $"{c.Number} {c.Branch}"
			}).ToList();
			ViewBag.Class = new SelectList(classes, "Class_Id", "NumberAndBranch");

			return View();
		}
		[HttpPost]
		public IActionResult StudentAdd(entity.Concrate.Student s)
		{
			Context.Students.Add(s);
			Context.SaveChanges();
			return RedirectToAction("Index", "Student");
		}
		public IActionResult StudentDelete(int id)
		{
			var silinecek = Context.Students.Find(id);
			Context.Students.Remove(silinecek);
			Context.SaveChanges();
			return RedirectToAction("Index", "Student");
		}
		public IActionResult StudentGet(int id)
		{
			var parents = Context.Parents.Select(p => new
			{
				Parent_Id = p.Parent_Id,
				NameAndSurname = $"{p.FirstName} {p.LastName} {"|"} {"TC:"} {p.TC}"
			}).ToList();
			ViewBag.Parent = new SelectList(parents, "Parent_Id", "NameAndSurname");

			var classes = Context.Classes.Select(c => new
			{
				Class_Id = c.Class_Id,
				NumberAndBranch = $"{c.Number} {c.Branch}"
			}).ToList();
			ViewBag.Class = new SelectList(classes, "Class_Id", "NumberAndBranch");
			var getirilecek = Context.Students.Find(id);
			return View("StudentGet", getirilecek);
		}
		public IActionResult StudentUpdate(entity.Concrate.Student s)
		{
			var guncellenecek = Context.Students.Find(s.Student_Id);
			guncellenecek.Student_Id = s.Student_Id;
			guncellenecek.FirstName = s.FirstName;
			guncellenecek.LastName = s.LastName;
			guncellenecek.TC = s.TC;
			guncellenecek.BirthDay = s.BirthDay;
			guncellenecek.Phone = s.Phone;
			guncellenecek.Email = s.Email;
			guncellenecek.Status = s.Status;
			guncellenecek.Class_Id = s.Class_Id;
			guncellenecek.Parent_Id = s.Parent_Id;
			Context.SaveChanges();
			return RedirectToAction("Index", "Student");
		}
	}

}
