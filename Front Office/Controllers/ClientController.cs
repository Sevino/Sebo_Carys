using Front_Office.Models;
using Front_Office.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front_Office.Controllers
{
    public class ClientController : Controller
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

        [HttpPost]
        public ActionResult Connexion(Client client)
        {
            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    Categories = context.ObtenirCategories(),
                    Client = context.ConnecterClient(client.EmailClient, client.MotDePasseClient)
                };
                return View(model);
            }
        }
    }
}