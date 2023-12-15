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
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());
        public ActionResult adminList()
        {
            var values = adm.GetAdminsList();
            return View(values);
        }
        [HttpGet]
        public ActionResult addAdmin()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult addAdmin(Admin a)
        {
            adm.AdminAdd(a);
            return RedirectToAction("adminList");
        }
        public ActionResult deleteAdmin(int id)
        {
            var sil = adm.GetAdmin(id);
            adm.AdminRemove(sil);
            return RedirectToAction("adminList");
        }
        [HttpGet]
        public ActionResult updateAdmin(int id)
        {
            
            var getir = adm.GetAdmin(id);
            return View(getir);
        }
        [HttpPost]
        public ActionResult updateAdmin(Admin admin)
        {
            adm.AdminUpdate(admin);

            return RedirectToAction("adminList");
        }
    }
}