using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProKampi.Controllers
{
	[AllowAnonymous]
    public class LoginController : Controller
    {
		Context c = new Context();
		WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
		AdminLoginManager alm = new AdminLoginManager(new EFAdminDal());
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult adminLogin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult adminLogin(Admin admin)
		{
			//var value = c.Admins.FirstOrDefault(x => x.password == admin.password && x.adminUsername == admin.adminUsername);
			var values = alm.GetAdmin(admin.adminUsername, admin.password);
			if (values!=null)//values boş değilse yani kullanıcı adı ve şifre birbibine uyan değer varsa
			{
				FormsAuthentication.SetAuthCookie(values.adminUsername, false);
				Session["adminUsername"] = values.adminUsername;
				return RedirectToAction("cateList", "AdminCategory");
			}
			else
			{
				return RedirectToAction("adminLogin","Login");
			}
			
		}
		[HttpGet]
		public ActionResult writerLogin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult writerLogin(Writer p)
		{
			//var values=c.Writers.FirstOrDefault(x=>x.writerMail== wrt.writerMail && x.WriterPassword==wrt.WriterPassword);
			var values = wlm.getWriter(p.writerMail, p.WriterPassword);
			if (values!=null)
			{
				FormsAuthentication.SetAuthCookie(values.writerMail, false);
				Session["WriterMail"] = values.writerMail;
				return RedirectToAction("writerProfile", "WriterPanel");

			}
			else
			{
				return RedirectToAction("writerLogin","Login");
			}
			
		}
		public ActionResult logOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("HomePage", "Home");
		}
	}
}