using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class SubscribeController : Controller
	{
		Context Context = new Context();
		[HttpPost]
		public IActionResult Index(Subscribe s)
		{
			Context.Subscribes.Add(s);
			Context.SaveChanges();
			return RedirectToAction("Index", "Blog");
		}
	}
}
