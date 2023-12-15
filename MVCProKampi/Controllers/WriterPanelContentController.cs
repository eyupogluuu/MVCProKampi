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
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult myContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo=c.Writers.Where(x=>x.writerMail==p).Select(y=>y.writerID).FirstOrDefault();
            
            var values=cm.GetContentByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult newEntry(int id)
        {
            ViewBag.d=id;   
            return View();
        }
        [HttpPost]
        public ActionResult newEntry(Content con)
        {

            string mail = (string)Session["WriterMail"];
            
            var writerid = c.Writers.Where(x => x.writerMail == mail).Select(y => y.writerID).FirstOrDefault();
            con.contentDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            con.writerID = writerid;
            con.contentStatus = true;
            cm.ContentAdd(con);
            return RedirectToAction("myContent");

        }
    }
}