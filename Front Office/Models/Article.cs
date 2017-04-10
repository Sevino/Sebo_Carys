namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            LigneCommandes = new HashSet<LigneCommande>();
            LigneCommandeFournisseurs = new HashSet<LigneCommandeFournisseur>();
            LigneLivraisons = new HashSet<LigneLivraison>();
            StockArticles = new HashSet<StockArticle>();
            Acteurs = new HashSet<Acteur>();
            Promotions = new HashSet<Promotion>();
        }

        [Key]
        public int Reference { get; set; }

        [Required]
        [StringLength(200)]
        public string LibelleArticle { get; set; }

        public double Prix { get; set; }

        [StringLength(200)]
        public string PhotoArticle { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DescriptionArticle { get; set; }

        public bool? Reapprovisionnable { get; set; }

        public double PrixFournisseur { get; set; }

        public int IdStock { get; set; }

        public int IdGenre { get; set; }

        public double? PrixAchat { get; set; }

        public int IdFournisseur { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }

        public virtual Genre Genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneCommandeFournisseur> LigneCommandeFournisseurs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneLivraison> LigneLivraisons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockArticle> StockArticles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acteur> Acteurs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
