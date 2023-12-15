using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
		public ActionResult headingLayout()
		{
            var values = hm.GetHeaadingList();
			return View(values);
		}

        public PartialViewResult contentList(int id = 0)
        {
            var values = cm.GetContentByHeadingId(id);
            return PartialView(values);
        }
        
    }
}