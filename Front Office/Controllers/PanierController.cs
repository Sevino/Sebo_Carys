using Front_Office.Models;
using Front_Office.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front_Office.Controllers
{
    [Authorize]
    public class PanierController : Controller
    {
        PanierCommande panier = new Front().ObtenirPanier(new BddContext().Clients.First(c => c.NumeroClient == 1));

        public ActionResult Index()
        {
            using (var context = new Front())
            {
                List<LigneCommande> lignes = context.ObtenirListeArticles(panier);

                return View(lignes);
            }
        }

        public ActionResult Ajouter(int id)
        {
            using (var context = new Front())
            {
                context.AjouterArticle(panier, context.ObtenirArticle(id));
            };

            return RedirectToAction("Index");
        }

        public ActionResult Supprimer(int id)
        {
            using (var context = new Front())
            {
                context.SupprimerArticle(panier, context.ObtenirArticle(id));
            };

            return RedirectToAction("Index");
        }
    }
}