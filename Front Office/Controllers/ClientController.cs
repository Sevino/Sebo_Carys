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
        public ActionResult Connexion()
        {
            using (var context = new Front())
            {
                ClientViewModel model = new ClientViewModel
                {
                    Connecte = false
            };
            return View(model);
        }
    }

        [HttpPost]
        public ActionResult Connexion(Client client)
        {
            using (var context = new Front())
            {
                ClientViewModel model = new ClientViewModel
                {
                    Client = context.ConnecterClient(client.EmailClient, client.MotDePasseClient),
                    Connecte = true
                };
                return View(model);
            }
        }

        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(Client client)
        {
            using (var context = new Front())
            {
                HomeViewModel model = new HomeViewModel
                {
                    Client = context.ConnecterClient(client.EmailClient, client.MotDePasseClient)
                };
                return View(model);
            }
        }
    }
}