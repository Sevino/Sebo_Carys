using Front_Office.Models;
using Front_Office.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front_Office.Controllers
{
    public class CatalogueController : Controller
    {
        public ActionResult Index(int? id)
        {
            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    CategorieChoisie = id.HasValue ? context.ObtenirCategorie(id.Value) : null,
                    Articles = id.HasValue ? context.ObtenirArticlesParCategorie(context.ObtenirCategorie(id.Value)) : context.ObtenirArticles()
                };
                return View(model);
            }
        }

        public ActionResult Article(int id)
        {
            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    ArticleChoisi = context.ObtenirArticle(id)
                };
                return View(model);
            }
        }
    }
}