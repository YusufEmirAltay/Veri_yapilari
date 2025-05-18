using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class ContactController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact c)
		{
			Context.Contacts.Add(c);
			Context.SaveChanges();
			return RedirectToAction("Thanks", "Contact");
			return View();
		}

		[HttpGet]
		public IActionResult Thanks()
		{
			return View();
		}
	}
}
