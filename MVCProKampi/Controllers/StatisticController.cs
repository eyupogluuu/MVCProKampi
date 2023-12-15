using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.kategorisay = c.Categories.Count();
            ViewBag.basliksay = c.Headings.Where(x => x.categoryID ==3).ToList().Count();
            ViewBag.yazaradi = c.Writers.Where(x => x.writerName.Contains("a")).Count();
            
            return View();
        }
    }
}