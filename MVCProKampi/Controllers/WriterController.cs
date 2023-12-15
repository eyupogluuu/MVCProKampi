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

namespace MVCProKampi.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EFWriterDal());
		public ActionResult writerList()
		{
			var values = wm.GetWriterList();
			return View(values);
		}
		[HttpGet]
		public ActionResult writerAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult writerAdd(Writer writer)
		{
			WriterValidator vd= new WriterValidator();
			ValidationResult result= vd.Validate(writer);
			if (result.IsValid)
			{
				wm.WriterAdd(writer);
				return RedirectToAction("writerList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		[HttpGet]
		public ActionResult writerUpdate(int id)
		{
			var value = wm.GetWriter(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult writerUpdate(Writer writer)
		{
			wm.WriterUpdate(writer);
			return RedirectToAction("writerList");
		}
	}
}