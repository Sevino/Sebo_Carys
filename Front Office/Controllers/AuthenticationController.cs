using Front_Office.Models;
using Front_Office.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Controleur de l'authentification
/// </summary>
namespace Front_Office.Controllers
{
    public class AuthenticationController : Controller
    {
        /// <summary>
        /// Fonction qui renvoi a la page d'authentification
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]  // Autorisé si non authentifié
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Fonction de login
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]    // Autorisé si non authentifié
        [ValidateAntiForgeryToken]  //Protection contre les Cross-Site Request Forgery
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            // Si les information rentré ne correspondent pas au modèle
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Si les utilisateur ne sont pas valides
            if (!ValidateUser(model.Login, model.Password))
            {
                ModelState.AddModelError(string.Empty, "Le nom d'utilisateur ou le mot de passe est incorrect.");
                return View(model);
            }

            // Si l'authentification est reussie alors on ajoute l'identifiant au cookie d'identification
            var loginClaim = new Claim(ClaimTypes.NameIdentifier, model.Login);
            var claimsIdentity = new ClaimsIdentity(new[] { loginClaim }, DefaultAuthenticationTypes.ApplicationCookie);
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(claimsIdentity);

            // On redirige vers l'URL d'origine
            if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                return Redirect(ViewBag.ReturnUrl);
            // Par defaut on redirige vers la page d'acceuil du site
            return RedirectToAction("Index", "Home");

        }

        /// <summary>
        /// Fonction de deconnexion du compte
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize] // Autorisé si on est identifié
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();

            // Redirection vers l'accueil 
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Fonction de validation des couples login/mdp
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ValidateUser(string login, string password)
        {
            bool isValid;
            // Verification du couple Login/mot de passe par rapport a la base de données
            using (var context = new Front())
            {
                isValid = context.VerifierLoginMotDePasse(login, password);
            }

            return isValid;
        }
    }
}