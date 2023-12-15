using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProKampi.Controllers
{
	[AllowAnonymous]

	public class HomeController : Controller
	{
		Context c = new Context();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult homePage()
		{
			return View();
		}
		public PartialViewResult homeHead()
		{
			return PartialView();
		}
		public PartialViewResult homeHeader()
		{
			return PartialView();
		}
		public PartialViewResult homeTool()
		{
			var values = c.Tools.ToList();
			return PartialView(values);
		}
		public PartialViewResult whatIDo()
		{
			var values = c.WhatIDos.ToList();
			return PartialView(values);
		}
		public PartialViewResult homeImage()
		{
			var values = c.HomeImages.ToList();
			return PartialView(values);
		}
		public PartialViewResult homeStatistic()
		{
			ViewBag.wc = c.Writers.Count();
			ViewBag.hc = c.Headings.Count();
			ViewBag.cc = c.Contents.Count();
			return PartialView();
		}
		public PartialViewResult homeTestimonial()
		{
			var values = c.Testimonials.ToList();
			return PartialView(values);
		}
		public PartialViewResult homeCommunucation()
		{
			var values = c.HomeCommunications.ToList();
			return PartialView(values);
		}
		[HttpGet]
		public ActionResult homeContact()
		{
			
			return PartialView();
		}
		[HttpPost]
		public ActionResult homeContact(HomeContact contact)
		{
			c.HomeContacts.Add(contact);
			c.SaveChanges();
			return RedirectToAction("homePage");
		}
		public PartialViewResult homeFooter()
		{
			return PartialView();
		}
		public ActionResult sweetAlert()
		{
			return View();
		}
	}
}