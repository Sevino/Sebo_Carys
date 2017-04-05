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
                    Categories = context.ObtenirCategories(),
                    CategorieChoisie = null,
                    Articles = context.ObtenirArticles()
                };
                return View(model);
            }
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

        public ActionResult Catalogue(int? id)
        {
            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    Categories = context.ObtenirCategories(),
                    CategorieChoisie = (id.HasValue ? context.ObtenirCategorie(id.Value) : null),
                    Articles = (id.HasValue ? context.ObtenirArticlesParCategorie(context.ObtenirCategorie(id.Value)) : context.ObtenirArticles())
                };
                return View(model);
            }
        }
    }
}