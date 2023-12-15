using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
	public class AdminCategoryController : Controller
	{
		CategoryManager cm = new CategoryManager(new EFCategoryDal());
		public ActionResult cateList()
		{
			var values = cm.GetCategoriesList();
			return View(values);
		}
		[HttpGet]
		public ActionResult cateAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult cateAdd(Category c)
		{
			CategoryValidator validator = new CategoryValidator();
			ValidationResult result = validator.Validate(c);
			if (result.IsValid)//validasyonlar sağlandıysa
			{
				cm.CategoryAdd(c);
				return RedirectToAction("cateList");
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
		public ActionResult cateDelete(int id)
		{
			var values = cm.GetCategory(id);
			cm.CategoryRemove(values);
			return RedirectToAction("cateList");
		}
		[HttpGet]
		public ActionResult cateUpdate(int id)
		{
			var values=cm.GetCategory(id);
			return View(values);
		}
		[HttpPost]
		public ActionResult cateUpdate(Category category)
		{
			cm.CategoryUpdate(category);
			return RedirectToAction("cateList");
		}
	}
}