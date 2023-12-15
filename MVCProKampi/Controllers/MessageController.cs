using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mvalidator= new MessageValidator();
        Context c = new Context();
        [Authorize]
        public ActionResult Inbox(string p)
        {

            
			var values=mm.GetMessageInbox(p);
            return View(values);
        }
		public ActionResult SendBox(string p)
		{
            
			var values = mm.GetMessageSendbox(p);
			return View(values);
		}
        public ActionResult InboxMessageDetail(int id)
        {
            var values = mm.GetMessage(id);            
            return View(values);
        }
        public ActionResult SendboxMessageDetail(int id)
        {
            var values= mm.GetMessage(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
		[HttpPost]
		public ActionResult AddMessage(Message message)
		{
            ValidationResult result= mvalidator.Validate(message);// result ile mesajın validasyon kontrolünü yap
            if (result.IsValid)//validasyonlar tamamsa
            {
                message.messageDate=DateTime.Parse(DateTime.Now.ToString());
                mm.AddMessage(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            mm.AddMessage(message);
            return View();
		}

	}
}