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
    public class ContentController : Controller
    {
        Context c = new Context();
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getallContent(string p="")
        {
            var values = cm.GetContentList(p);
           
            return View(values);
        }
		public ActionResult contentbyHeading(int id)
		{
           // ViewBag.baslik=c.Contents.Where(x=>x.headingID==id).Select(y=>y.heading.headingName).FirstOrDefault();
            var values = cm.GetContentByHeadingId(id);
			return View(values);
		}
        public ActionResult contentDelete(int id)
        {
            var values=cm.GetByID(id);
            return View(values);
        }
	}
}