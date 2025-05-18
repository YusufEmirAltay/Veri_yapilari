using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class BlogController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Blogs.ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult PostAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult PostAdd(Blog p)
		{
			Context.Blogs.Add(p);
			Context.SaveChanges();
			return RedirectToAction("Index", "Blog");
		}
		public IActionResult PostDelete(int id)
		{
			var w = Context.Blogs.Find(id);
			Context.Blogs.Remove(w);
			Context.SaveChanges();
			return RedirectToAction("Index", "Blog");
		}
		public IActionResult PostGet(int id)
		{
			var e = Context.Blogs.Find(id);
			return View("PostGet", e);
		}
		public IActionResult PostUpdate(Blog s)
		{
			var r = Context.Blogs.Find(s.BlogPost_Id);
			r.BlogPost_Id = s.BlogPost_Id;
			r.Title = s.Title;
			r.Summary = s.Summary;
			r.Article = s.Article;
			r.Status = s.Status;
			Context.SaveChanges();
			return RedirectToAction("Index", "Blog");
		}
	}
}
