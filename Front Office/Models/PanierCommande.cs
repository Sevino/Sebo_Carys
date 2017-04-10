namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PanierCommande")]
    public partial class PanierCommande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PanierCommande()
        {
            LigneCommandes = new HashSet<LigneCommande>();
            Livraisons = new HashSet<Livraison>();
            Paiements = new HashSet<Paiement>();
        }

        [Key]
        public int NumeroCommande { get; set; }

        public DateTime DateCommande { get; set; }

        public int IdEtat { get; set; }

        public int? IdPaiement { get; set; }

        public int NumeroClient { get; set; }

        public virtual EtatCommande EtatCommande { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Livraison> Livraisons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
