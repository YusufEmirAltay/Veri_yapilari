using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class QuickController : Controller
	{
		Context Context=new Context();
		[HttpGet]
		public IActionResult StudentAdd()
		{
			ViewBag.City = Context.Cities.ToList();
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
	}
}
