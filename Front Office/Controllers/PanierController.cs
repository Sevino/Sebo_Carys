using Front_Office.Models;
using Front_Office.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Front_Office.Controllers
{
    [Authorize]   // Autorisé si on est identifié
    public class PanierController : Controller
    {
        PanierCommande panier;

        void Panier()
        {
            var claimIdentity = User.Identity as ClaimsIdentity;
            var identifiant = new Front().RecupererInformationClient(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value).NumeroClient;
            panier = new Front().ObtenirPanier(new BddContext().Clients.First(c => c.NumeroClient == identifiant));
        }

        public ActionResult Index()
        {
            Panier();
            using (var context = new Front())
            {
                List<LigneCommande> lignes = context.ObtenirListeArticles(panier);

                return View(lignes);
            }
        }

        public ActionResult Ajouter(int id)
        {
            Panier();
            using (var context = new Front())
            {
                context.AjouterArticle(panier, context.ObtenirArticle(id));
            };

            return RedirectToAction("Index");
        }

        public ActionResult Supprimer(int id)
        {
            Panier();
            using (var context = new Front())
            {
                context.SupprimerArticle(panier, context.ObtenirArticle(id));
            };

            return RedirectToAction("Index");
        }

        public ActionResult Facture()
        {
            Panier();
            using (var context = new Front())
            {
                context.ValiderPanier(panier);
            };
            return View(panier);
        }
    }
}