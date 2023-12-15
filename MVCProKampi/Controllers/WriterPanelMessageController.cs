using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;


namespace MVCProKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();
        public ActionResult writerInbox()
        {
            string p = (string)Session["WriterMail"];
            var values = mm.GetMessageInbox(p);
            return View(values);
        }
        public ActionResult writerSendbox()
        {
            string p = (string)Session["WriterMail"];
            var values = mm.GetMessageSendbox(p);
            return View(values);
        }
        public ActionResult messageDetailInbox(int id)
        {
            var values = mm.GetMessage(id);
            return View(values);
        }
        public ActionResult messageDetailSendbox(int id)
        {
            var values = mm.GetMessage(id);
            return View(values);
        }
        public PartialViewResult writerListPartial()
        {
            string userEmail = (string)Session["WriterMail"];

            var listResult = mm.GetMessageSendbox(userEmail);
            var sendList = listResult.FindAll(x => x.isDraft == false);
            ViewBag.sendCount = sendList.Count();
            var listResult2 = mm.GetMessageInbox(userEmail);
            ViewBag.inboxCount = listResult2.Count();
            var drafList = listResult.FindAll(x => x.isDraft == true);
            ViewBag.draftCount = drafList.Count();
            return PartialView();



        }
        [HttpGet]
        public ActionResult newMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult newMessage(EntityLayer.Concrete.Message mes, string button)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = mv.Validate(mes);
            if (button == "draft")
            {

                result = mv.Validate(mes);
                if (result.IsValid)
                {
                    mes.messageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mes.senderMail = sender;
                    mes.isDraft = true;
                    mm.AddMessage(mes);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "save")
            {
                if (result.IsValid)
                {
                    mes.messageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mes.senderMail = sender;
                    mes.isDraft = false;
                    mm.AddMessage(mes);
                    return RedirectToAction("writerSendbox");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                
            }
            else if (button == "exit")
            {
                return RedirectToAction("writerSendbox");
            }
            return View();
        }
        public ActionResult Draft()
        {
            string userEmail = (string)Session["WriterMail"];
            var sendList = mm.GetMessageSendbox(userEmail);
            var draftList = sendList.FindAll(x => x.isDraft == true);
            return View(draftList);
        }
        public ActionResult draftMessageDetails(int id)
        {
            var Values = mm.GetMessage(id);
            return View(Values);
        }


    }
}