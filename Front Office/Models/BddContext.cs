namespace Front_Office.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class BddContext : DbContext
    {
        public BddContext()
            : base("name=BddContext")
        {
        }

        public virtual DbSet<Acteur> Acteurs { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CommandeFournisseur> CommandeFournisseurs { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<LigneCommande> LigneCommandes { get; set; }
        public virtual DbSet<LigneCommandeFournisseur> LigneCommandeFournisseurs { get; set; }
        public virtual DbSet<LigneLivraison> LigneLivraisons { get; set; }
        public virtual DbSet<Livraison> Livraisons { get; set; }
        public virtual DbSet<Paiement> Paiements { get; set; }
        public virtual DbSet<PanierCommande> PanierCommandes { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StockArticle> StockArticles { get; set; }

        public static List<Categorie> ObtenirCategories()
        {
            return new BddContext().Categories.ToList();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acteur>()
                .Property(e => e.NomActeur)
                .IsUnicode(false);

            modelBuilder.Entity<Acteur>()
                .HasMany(e => e.Articles)
                .WithMany(e => e.Acteurs)
                .Map(m => m.ToTable("ActeurArticle").MapLeftKey("IdActeur").MapRightKey("Reference"));

            modelBuilder.Entity<Article>()
                .Property(e => e.LibelleArticle)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.LigneCommandes)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.LigneCommandeFournisseurs)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.LigneLivraisons)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasOptional(e => e.StockArticle)
                .WithRequired(e => e.Article);

            modelBuilder.Entity<Categorie>()
                .Property(e => e.LibelleCategorie)
                .IsUnicode(false);

            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Genres)
                .WithRequired(e => e.Categorie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.NomClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PrenomClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.AdresseClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CodePostalClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.VilleClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.EmailClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.MotDePasseClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.PanierCommandes)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommandeFournisseur>()
                .HasMany(e => e.LigneCommandeFournisseurs)
                .WithRequired(e => e.CommandeFournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.NomFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Fournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fournisseur>()
                .HasMany(e => e.CommandeFournisseurs)
                .WithRequired(e => e.Fournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.LibelleGenre)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Livraison>()
                .HasMany(e => e.LigneLivraisons)
                .WithRequired(e => e.Livraison)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paiement>()
                .Property(e => e.ModePaiement)
                .IsUnicode(false);

            modelBuilder.Entity<Paiement>()
                .HasMany(e => e.PanierCommandes)
                .WithRequired(e => e.Paiement)
                .HasForeignKey(e => e.IdPaiement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PanierCommande>()
                .Property(e => e.EtatCommande)
                .IsUnicode(false);

            modelBuilder.Entity<PanierCommande>()
                .HasMany(e => e.LigneCommandes)
                .WithRequired(e => e.PanierCommande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PanierCommande>()
                .HasMany(e => e.Livraisons)
                .WithRequired(e => e.PanierCommande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PanierCommande>()
                .HasMany(e => e.Paiements)
                .WithRequired(e => e.PanierCommande)
                .HasForeignKey(e => e.NumeroCommande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Articles)
                .WithMany(e => e.Promotions)
                .Map(m => m.ToTable("PromotionArticle").MapLeftKey("IdPromotion").MapRightKey("Reference"));

            modelBuilder.Entity<Role>()
                .Property(e => e.LibelleRole)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Acteurs)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
