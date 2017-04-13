using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Office.Models
{
    public class Front : IDal
    {
        private BddContext bdd;

        public Front()
        {
            bdd = new BddContext();
        }

        public void AjouterCategorie(string nom, double tva)
        {
            if (ObtenirCategorieParNom(nom) == null)
            {
                bdd.Categories.Add(new Categorie { LibelleCategorie = nom, Tva = tva });
                bdd.SaveChanges();
            }
        }

        public List<Categorie> ObtenirCategories()
        {
            return bdd.Categories.ToList();
        }

        public Categorie ObtenirCategorie(int id)
        {
            return bdd.Categories.Where(categorie => categorie.IdCategorie == id).FirstOrDefault();
        }

        public Categorie ObtenirCategorieParNom(string nom)
        {
            return bdd.Categories.Where(categorie => categorie.LibelleCategorie == nom).FirstOrDefault();
        }

        public void AjouterGenre(string nom, Categorie categorie)
        {
            if (ObtenirGenreParNom(nom) == null)
            {
                bdd.Genres.Add(new Genre { LibelleGenre = nom, Categorie = categorie });
                bdd.SaveChanges();
            }
        }

        public List<Genre> ObtenirGenres()
        {
            return bdd.Genres.ToList();
        }

        public List<Genre> ObtenirGenresParCategorie(Categorie categorie)
        {
            return bdd.Genres.Where(genre => genre.Categorie.IdCategorie == categorie.IdCategorie).ToList();
        }

        public Genre ObtenirGenre(int id)
        {
            return bdd.Genres.Where(genre => genre.IdGenre == id).FirstOrDefault();
        }

        public Genre ObtenirGenreParNom(string nom)
        {
            return bdd.Genres.Where(genre => genre.LibelleGenre == nom).FirstOrDefault();
        }

        public List<Article> ObtenirArticles()
        {
            return bdd.Articles.ToList();
        }

        public List<Article> ObtenirArticlesParCategorie(Categorie categorie)
        {
            return bdd.Articles.Where(article => article.Genre.Categorie.IdCategorie == categorie.IdCategorie).ToList();
        }

        public Article ObtenirArticle(int id)
        {
            return bdd.Articles.Where(article => article.Reference == id).FirstOrDefault();
        }

        public Client ConnecterClient(string email, string motDePasse)
        {
            return bdd.Clients.Where(client => client.EmailClient == email && client.MotDePasseClient == motDePasse).FirstOrDefault();
        }

        /// <summary>
        ///  Fonction qui inscrit un nouveau client dans la base de donnée
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="adresse"></param>
        /// <param name="codePostal"></param>
        /// <param name="ville"></param>
        /// <param name="email"></param>
        /// <param name="motDePasse"></param>
        /// <param name="numTel"></param>
        public void InscriptionClient(string nom, string prenom, string adresse, string codePostal, string ville, string email, string motDePasse, string numTel)
        {
            bdd.Clients.Add(new Client
            {
                NomClient = nom,
                PrenomClient = prenom,
                AdresseClient = adresse,
                CodePostalClient = codePostal,
                VilleClient = ville,
                EmailClient = email,
                MotDePasseClient = motDePasse,
                TelephoneClient = numTel
            });
            bdd.SaveChanges();
        }
        /// <summary>
        /// Fonction qui verifie l'existence
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns> Return true si le client existe et false si il n'existe pas</returns>
        public bool VerifierExistenceClient(string email)
        {
            if (bdd.Clients.Where(client => client.EmailClient == email).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verirife que le couple mdp/id passer en parametre existe dans la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerifierLoginMotDePasse(string id, string password)
        {
            // Si le couple Id / Password est le bon dans la base on renvoi true
            if (bdd.Clients.Where(client => client.EmailClient == id && client.MotDePasseClient == password).FirstOrDefault() != null)
            {
                return true;
            }
            // Sinon on renvoi false
            return false;
        }

        /// <summary>
        /// Recupère les info d'un client a partir de son ID
        /// </summary>
        /// <param name="identifiant"></param>
        /// <returns></returns>
        public Client RecupererInformationClient(string identifiant)
        {
            var clientInfo = bdd.Clients.Where(client => client.EmailClient == identifiant).FirstOrDefault();
            return clientInfo;
        }

        /// <summary>
        /// Actualise les données d'un client passé en paramètre
        /// </summary>
        /// <param name="c"></param>
        public void UpdateClient(Client c)
        {
            var cli = bdd.Clients.Where(client => client.EmailClient == c.EmailClient).FirstOrDefault();
            cli.AdresseClient = c.AdresseClient;
            cli.CodePostalClient = c.CodePostalClient;
            cli.MotDePasseClient = c.MotDePasseClient;
            cli.NomClient = c.NomClient;
            cli.PrenomClient = c.PrenomClient;
            cli.TelephoneClient = c.TelephoneClient;
            cli.VilleClient = c.VilleClient;
            bdd.SaveChanges();
        }




        public void Dispose()
        {
            //bdd.Dispose();
        }

        public void AjouterArticle(PanierCommande panier, Article article)
        {
            LigneCommande ligne = bdd.LigneCommandes.SingleOrDefault(l => l.NumeroCommande == panier.NumeroCommande && l.Reference == article.Reference);
            if (ligne == null)
            {
                bdd.LigneCommandes.Add(new LigneCommande { Reference = article.Reference, NumeroCommande = panier.NumeroCommande, QuantiteCommande = 1, PrixUnitaire = article.Prix });
            }
            else
            {
                ligne.QuantiteCommande++;
            }
            bdd.SaveChanges();
        }

        public void SupprimerArticle(PanierCommande panier, Article article)
        {
            LigneCommande ligne = bdd.LigneCommandes.SingleOrDefault(l => l.NumeroCommande == panier.NumeroCommande && l.Reference == article.Reference);
            bdd.LigneCommandes.Remove(ligne);
            bdd.SaveChanges();
        }

        public PanierCommande ObtenirPanier(Client client)
        {
            PanierCommande panier = bdd.PanierCommandes.SingleOrDefault(c => c.NumeroClient == client.NumeroClient && c.EtatCommande.LibelleEtat == "Panier");
            if (panier == null)
            {
                panier = bdd.PanierCommandes.Add(new PanierCommande { DateCommande = DateTime.Now, NumeroClient = client.NumeroClient, IdEtat = bdd.EtatCommandes.First(e => e.LibelleEtat == "Panier").IdEtat });
                bdd.SaveChanges();
            }

            return panier;
        }

        public List<LigneCommande> ObtenirListeArticles(PanierCommande panier)
        {
            return bdd.LigneCommandes.Where(l => l.NumeroCommande == panier.NumeroCommande).ToList();
        }

        public int ObtenirNombreArticles(PanierCommande panier)
        {
            return bdd.LigneCommandes.Where(l => l.NumeroCommande == panier.NumeroCommande).Count();
        }

        public void ValiderPanier(PanierCommande commande)
        {
            PanierCommande panier = bdd.PanierCommandes.SingleOrDefault(c => c.NumeroCommande == commande.NumeroCommande);
            panier.IdEtat = bdd.EtatCommandes.First(e => e.LibelleEtat == "En attente de paiement").IdEtat;
            panier.DateCommande = DateTime.Now;
            bdd.SaveChanges();
        }
    }
}