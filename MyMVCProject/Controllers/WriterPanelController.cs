using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyMVCProject.Controllers
{
	public class WriterPanelController : Controller
	{
		HeadingManager hm = new HeadingManager(new EfHeadingDal());
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult MyHeading()
		{

			var values = hm.GetListByWriter();
			return View(values);
		}

		[HttpGet]
		public IActionResult NewHeading()
		{
			List<SelectListItem> valuecategory = (from x in cm.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryID.ToString()
												  }).ToList();
			ViewBag.vlc = valuecategory;
			return View();
		}
		[HttpPost]
		public IActionResult NewHeading(Heading p)
		{
			p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.WriterID = 4;
			p.HeadingStatus = true;
			hm.HeadingAdd(p);
			return RedirectToAction("MyHeading");

		}
		[HttpGet]
		public IActionResult EditHeading(int id)
		{
			List<SelectListItem> valuecategory = (from x in cm.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryID.ToString()
												  }).ToList();
			ViewBag.vlc = valuecategory;
			var HeadingValue = hm.GetByID(id);
			return View(HeadingValue);
		}

		[HttpPost]
		public IActionResult EditHeading(Heading p)
		{
			hm.HeadingUpdate(p);
			return RedirectToAction("MyHeading");
		}
		public IActionResult DeleteHeading(int id)
		{
			var headingValue = hm.GetByID(id);
			headingValue.HeadingStatus = false;
			hm.HeadingDelete(headingValue);
			return RedirectToAction("MyHeading");

		}

	}
}
