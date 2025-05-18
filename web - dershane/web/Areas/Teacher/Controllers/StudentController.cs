using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Teacher.Controllers
{
	[Area("Teacher")]
	[Authorize(Roles = "TEACHER")]
	public class StudentController : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{
			var degerler = Context.Students.ToList();
			return View(degerler);
		}
	}
}
