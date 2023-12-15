using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
	public class AboutController : Controller
	{
		AboutManager am = new AboutManager(new EFAboutDal());
		public ActionResult aboutList()
		{
			var values=am.GetAboutList();
			return View(values);
		}
		[HttpGet]
		public ActionResult aboutAdd()

		{
			return View();
		}
		[HttpPost]
		public ActionResult aboutAdd(About about)

		{
			am.AboutAdd(about);
			return RedirectToAction("aboutList");
		}
		public PartialViewResult aboutAddPartial()
		{
			return PartialView();
		}
	}
}