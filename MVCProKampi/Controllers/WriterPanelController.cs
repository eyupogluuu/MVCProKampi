using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
		Context c = new Context();

		[HttpGet]
		public ActionResult writerProfile(int id=0)
        {
			string p = (string)Session["WriterMail"];//sisteme giren lisinin mailini aldım session ile
            id = c.Writers.Where(x => x.writerMail == p).Select(x => x.writerID).FirstOrDefault();//sisteme giren kişinin idsini aldım
            var values = wm.GetWriter(id);//sisteme giren kişinin bilgilerini getir
			return View(values);//sisteme giren kişinin bilgileri sayfaya taşi
        }

		[HttpPost]
		public ActionResult writerProfile(Writer writer)
		{
			WriterValidator vd = new WriterValidator();
			ValidationResult result = vd.Validate(writer);
			if (result.IsValid)
			{
				wm.WriterUpdate(writer);
				return RedirectToAction("allHeading","WriterPanel");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public ActionResult myHeading(string p)
		{
           
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Headings.Where(x => x.writer.writerMail == p).Select(y => y.writerID).FirstOrDefault();
            var values = hm.GetHeaadingListByWriter(writeridinfo);
			return View(values);
		}
        [HttpGet]
        public ActionResult newHeading()
        {
            
			List<SelectListItem> cateList = (from x in cm.GetCategoriesList()
                                             select new SelectListItem
                                             {
                                                 Text = x.categoryName,
                                                 Value = x.categoryID.ToString()
                                             }).ToList();
            ViewBag.cate = cateList;
            return View();
        }
		[HttpPost]
		public ActionResult newHeading(Heading h)
		{
			string mailinfo = (string)Session["WriterMail"];//yazarın maili alındı nailinfo değişkeninde
			var writeridinfo =c.Writers.Where(x => x.writerMail == mailinfo).Select(y => y.writerID).FirstOrDefault();//mail ile yazarın maili eşleştirildi aynı yazar olsun diye
			h.headindDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.writerID = writeridinfo;// yazıyı ekleyen yazarın idsi burada kaydedildi
            h.headingStatus = true;
			hm.HeadingAdd(h);
			return RedirectToAction("myHeading");
		}
        [HttpGet]
        public ActionResult editHeading(int id)
        {
            List<SelectListItem> cateList = (from x in cm.GetCategoriesList()
                                             select new SelectListItem
                                             {
                                                 Text = x.categoryName,
                                                 Value = x.categoryID.ToString()
                                             }).ToList();
            ViewBag.cate = cateList;
            var values = hm.GetHeading(id);
            return View(values);
        }
        [HttpPost]
		public ActionResult editHeading(Heading h)
		{
			
			hm.HeadingUpdate(h);
			return RedirectToAction("myHeading");
		}
        public ActionResult deleteHeading(int id)
        {
            var values=hm.GetHeading(id);           
            hm.HeadingRemove(values);
            return RedirectToAction("myHeading");
        }
        public ActionResult allHeading(int p=1)
        {
            var values = hm.GetHeaadingList().ToPagedList(p,4);
            return View(values);    
        }
	}
}