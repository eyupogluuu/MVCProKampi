using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
	public class HeadingController : Controller
	{
		HeadingManager hm = new HeadingManager(new EFHeadingDal());
		CategoryManager cm = new CategoryManager(new EFCategoryDal());
		WriterManager wm = new WriterManager(new EFWriterDal());
		public ActionResult headingList()
		{
			var values = hm.GetHeaadingList();
			return View(values);
		}

        public ActionResult headingReport()
        {
            var values = hm.GetHeaadingList();
            return View(values);
        }

        Context c = new Context();
        public ActionResult headingListWriter(int id)
        {
            var values = c.Headings.Where(x=>x.writerID == id).ToList();
            return View(values);
        }
        [HttpGet]
		public ActionResult headingAdd()
		{
			List<SelectListItem> cate = (from x in cm.GetCategoriesList()
										 select new SelectListItem
										 {
											 Text = x.categoryName,
											 Value = x.categoryID.ToString()
										 }).ToList();
			ViewBag.clist = cate;


			List<SelectListItem> wrt = (from x in wm.GetWriterList()
										select new SelectListItem
										{
											Text = x.writerName + " " + x.writerSurname,
											Value = x.writerID.ToString()
										}).ToList();
			ViewBag.wlist = wrt;
			return View();
		}
		[HttpPost]
		public ActionResult headingAdd(Heading heading)
		{
			heading.headindDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			hm.HeadingAdd(heading);
			return RedirectToAction("headingList");
		}
		[HttpGet]
		public ActionResult headingUpdate(int id)
		{
			List<SelectListItem> cate = (from x in cm.GetCategoriesList()
										 select new SelectListItem
										 {
											 Text = x.categoryName,
											 Value = x.categoryID.ToString()
										 }).ToList();
			ViewBag.clist = cate;

			var values = hm.GetHeading(id);
			return View(values);
		}
		[HttpPost]
		public ActionResult headingUpdate(Heading heading)
		{

			hm.HeadingUpdate(heading);
			return RedirectToAction("headingList");
		}
		public ActionResult headingDelete(int id)
		{
			var values=hm.GetHeading(id);
			values.headingStatus = false;
			hm.HeadingRemove(values);
			return RedirectToAction("headingList");
		}
	}
}