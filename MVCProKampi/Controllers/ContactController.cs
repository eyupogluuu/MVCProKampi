using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        Context c = new Context();
        public ActionResult contactList()
        {
            var values=cm.GetContactList();
            return View(values);
        }
        public ActionResult contactDetail(int id) 
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        public PartialViewResult sidebarPartial()
        {
			int mc = c.Messages.Count();
			ViewBag.messagecount = mc;
            int cc = c.Contacts.Count();
            ViewBag.contactcount = cc;
			return PartialView();
        }
    }
}