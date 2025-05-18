using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class BlogController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Blogs.Where(x => x.Status == true).ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult Details(int id)
		{
			ViewBag.Posts = Context.Blogs.ToList();
			ViewBag.Comment = Context.Blogs.Where(x => x.BlogPost_Id == id).ToList();
			var e = Context.Blogs.Find(id);
			return View("Details", e);
		}
		[HttpPost]
		public IActionResult Details(Comment c)
		{
			Context.Comments.Add(c);
			Context.SaveChanges();
			return View();
		}
	}
}
