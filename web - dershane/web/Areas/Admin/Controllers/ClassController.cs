using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class ClassController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Classes.ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult ClassAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult ClassAdd(Class c)
		{
			Context.Classes.Add(c);
			Context.SaveChanges();
			return RedirectToAction("Index", "Class");
		}
		public IActionResult ClassDelete(int id)
		{
			var silinecek = Context.Classes.Find(id);
			Context.Classes.Remove(silinecek);
			Context.SaveChanges();
			return RedirectToAction("Index", "Class");
		}
		public IActionResult ClassGet(int id)
		{
			var getirilecek = Context.Classes.Find(id);
			return View("ClassGet", getirilecek);
		}
		public IActionResult ClassUpdate(Class c)
		{
			var guncellenecek = Context.Classes.Find(c.Class_Id);
			guncellenecek.Class_Id = c.Class_Id;
			guncellenecek.Number = c.Number;
			guncellenecek.Branch = c.Branch;
			guncellenecek.Status = c.Status;
			Context.SaveChanges();
			return RedirectToAction("Index", "Class");
		}
	}
}
