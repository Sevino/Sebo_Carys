using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Office.Models
{
    public interface IDal : IDisposable
    {
        void AjouterCategorie(string nom, double tva);
        List<Categorie> ObtenirCategories();
        Categorie ObtenirCategorie(int id);
        Categorie ObtenirCategorieParNom(string nom);
        void AjouterGenre(string nom, Categorie categorie);
        List<Genre> ObtenirGenres();
        List<Genre> ObtenirGenresParCategorie(Categorie categorie);
        Genre ObtenirGenre(int id);
        Genre ObtenirGenreParNom(string nom);
        List<Article> ObtenirArticles();
        List<Article> ObtenirArticlesParCategorie(Categorie categorie);
        Article ObtenirArticle(int id);
        Client ConnecterClient(string email, string motDePasse);
        void InscriptionClient(string nom, string prenom, string adresse, string codePostal, string ville, string email, string motDePasse, string numTel);
        void AjouterArticle(PanierCommande panier, Article article);
        void SupprimerArticle(PanierCommande panier, Article article);
        PanierCommande ObtenirPanier(Client client);
        List<LigneCommande> ObtenirListeArticles(PanierCommande panier);
        int ObtenirNombreArticles(PanierCommande panier);
    }
}