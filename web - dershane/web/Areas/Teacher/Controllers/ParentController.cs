using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Teacher.Controllers
{
	[Area("Teacher")]
	[Authorize(Roles = "TEACHER")]
	public class ParentController : Controller
	{
		Context Context=new Context();
		public IActionResult Index()
		{
			ViewBag.Ogrenci=Context.Students.ToList();
			var degerler=Context.Parents.ToList();
			return View(degerler);
		}
	}
}
