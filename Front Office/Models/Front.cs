﻿using System;
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

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}