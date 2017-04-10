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
                    Client = context.ConnecterClient(client.EmailClient, client.MotDePasseClient)
                };

                model.Connecte = model.Client == null ? false : true;
                model.Message = (ModelState.IsValid && model.Client == null) ? "Ce client n'existe pas" : "";

                return View(model);
            }
        }

        public ActionResult Inscription()
        {
            return View();
        }
        /// <summary>
        /// Fonction d'inscription dans la base d'un client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Inscription(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var context = new Front())
            {
                //Inscription du client dans la base
                context.InscriptionClient(client.NomClient, client.PrenomClient, client.AdresseClient, client.CodePostalClient, client.VilleClient, client.EmailClient, client.MotDePasseClient, client.TelephoneClient);
                ClientViewModel model = new ClientViewModel
                {                   
                    Connecte = false
                };
                // On renvoi le client sur la page de connexion
                return RedirectToAction("Connexion");
            }
        }        
    }
}