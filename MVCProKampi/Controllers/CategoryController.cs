using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MVCProKampi.Controllers
{
	public class CategoryController : Controller
	{
		CategoryManager cm = new CategoryManager(new EFCategoryDal());
		[Authorize(Roles="A")]
		public ActionResult categoryList()
		{
			var values = cm.GetCategoriesList();
			return View(values);
		}

		[HttpGet]
		public ActionResult categoryAdd()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult categoryAdd(Category c)
		{
			CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(c);
			if (result.IsValid)//validasyonlar sağlandıysa
			{
				cm.CategoryAdd(c);
				return RedirectToAction("categoryList");
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
	}
}