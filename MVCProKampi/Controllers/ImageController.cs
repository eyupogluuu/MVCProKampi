using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
    public class ImageController : Controller
    {
        ImageManager im = new ImageManager(new EFImageDal());
        public ActionResult imageList()
        {
            var values = im.GetImages();
            return View(values);
        }
    }
}