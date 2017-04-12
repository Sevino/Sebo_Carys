using Front_Office.Models;
using Front_Office.ViewModels;
using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Front_Office.Controllers
{
    public class ClientController : Controller
    {

        public ActionResult Inscription()
        {
            ClientViewModel model = new ClientViewModel
            {
                Connecte = false
            };
            return View(model);
        }
        /// <summary>
        /// Fonction d'inscription dans la base d'un client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        [CaptchaValidator]
        public ActionResult Inscription(Client client, bool captchaValid)
        {
            using (var context = new Front())
            {
                // Si les données ne sont pas bonne ou que le client existe deja on renvoi la page avec les erreurs
                if (!ModelState.IsValid || context.VerifierExistenceClient(client.EmailClient))
                {
                    ClientViewModel modelerror = new ClientViewModel
                    {
                        Connecte = false
                    };
                    if (context.VerifierExistenceClient(client.EmailClient))
                    {
                        modelerror.Message = "Erreur : Cette adresse mail est déja utilisée";
                    }
                    return View(modelerror);
                }
                //Inscription du client dans la base
                context.InscriptionClient(client.NomClient, client.PrenomClient, client.AdresseClient, client.CodePostalClient, client.VilleClient, client.EmailClient, client.MotDePasseClient, client.TelephoneClient);
                ClientViewModel model = new ClientViewModel
                {
                    Connecte = false
                };
                // On renvoi le client sur la page d'authentification
                return RedirectToAction("Login", "Authentication");
            }
        }

        
        public ActionResult Gestion()
        {
            var identifiant = "";
            var claimIdentity = User.Identity as ClaimsIdentity;
            identifiant =claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            using (var context = new Front())
            {
                ClientViewModel modelclient = new ClientViewModel
                {
                    Client = context.RecupererInformationClient(identifiant),
                    Connecte = true,                    
                };
                return View(modelclient);
            }            
        }

        [HttpPost]
        public ActionResult Gestion(Client client)
        {
            using (var context = new Front())
            {
                // Si les données ne sont pas bonne ou que le client existe deja on renvoi la page avec les erreurs
                if (!ModelState.IsValid)// || context.VerifierExistenceClient(client.EmailClient))
                {
                    ClientViewModel modelerror = new ClientViewModel
                    {                        
                    };
                    //if (context.VerifierExistenceClient(client.EmailClient))
                    //{
                    //    modelerror.Message = "Erreur : Cette adresse mail est déja utilisée";
                    //}
                    return View(modelerror);
                }
                //Inscription du client dans la base
                context.UpdateClient(client);
                ClientViewModel model = new ClientViewModel
                {                   
                };
                // On renvoie le client sur la page d'accueil
                return RedirectToAction("Index", "Home");
            }
        }
    }
}