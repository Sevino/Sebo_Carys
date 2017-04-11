using Front_Office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front_Office.Controllers
{
    public class PanierController : Controller
    {
        public ActionResult Index(int id)
        {
            using (var context = new Front())
            {
                PanierCommande commande = new PanierCommande();
                commande.LigneCommandes.Add(new LigneCommande { Reference = id, NumeroCommande = commande.NumeroCommande, QuantiteCommande = 1, PrixUnitaire = context.ObtenirArticle(id).Prix });
                HttpContext.Session["commande"] = commande;
            };
            return View();
        }
    }
}