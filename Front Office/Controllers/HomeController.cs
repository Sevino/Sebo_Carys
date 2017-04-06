using Front_Office.Models;
using Front_Office.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front_Office.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    Categories = context.ObtenirCategories()
                };
                return View(model);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    Categories = context.ObtenirCategories()
                };
                return View(model);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    Categories = context.ObtenirCategories()
                };
                return View(model);
            }
        }
    }
}