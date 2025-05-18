using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="ADMIN")]
	public class AdressController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.City = Context.Cities.ToList();
			var adresler = Context.Adresses.ToList();
			return View(adresler);
		}
		[HttpGet]
		public IActionResult AdressAdd()
		{
			ViewBag.City = Context.Cities.ToList();
			return View();
		}
		[HttpPost]
		public IActionResult AdressAdd(Adress a)
		{
			Context.Adresses.Add(a);
			Context.SaveChanges();
			return RedirectToAction("Index", "Adress");
		}
		public IActionResult AdressDelete(int id)
		{
			var silinecek = Context.Adresses.Find(id);
			Context.Adresses.Remove(silinecek);
			Context.SaveChanges();
			return RedirectToAction("Index", "Adress");
		}
		public IActionResult AdressGet(int id)
		{
			var e = Context.Adresses.Find(id);
			return View("AdressGet", e);
		}
		public IActionResult AdressUpdate(Adress a)
		{
			var guncellenecek = Context.Adresses.Find(a.Adress_Id);
			guncellenecek.Adress_Id = a.Adress_Id;
			guncellenecek.City = a.City;
			guncellenecek.Town = a.Town;
			guncellenecek.Neighbourhood = a.Neighbourhood;
			guncellenecek.Street = a.Street;
			guncellenecek.NO = a.NO;
			guncellenecek.Apartment = a.Apartment;
			Context.SaveChanges();
			return RedirectToAction("Index", "Adress");
		}
	}
}
