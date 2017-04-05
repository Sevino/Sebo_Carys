using Front_Office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Office.ViewModels
{
    public class HomeViewModel
    {
        public List<Categorie> Categories { get; set; }
        public Categorie CategorieChoisie { get; set; }
        public List<Article> Articles { get; set; }
        public Article ArticleChoisi { get; set; }
        public Client Client { get; set; }
    }
}