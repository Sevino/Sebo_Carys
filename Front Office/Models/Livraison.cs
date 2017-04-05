namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Livraison")]
    public partial class Livraison
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livraison()
        {
            LigneLivraisons = new HashSet<LigneLivraison>();
        }

        [Key]
        public int NumeroLivraison { get; set; }

        public DateTime DateLivraison { get; set; }

        public bool AccuseReception { get; set; }

        public bool LivraisonComplete { get; set; }

        public int NumeroCommande { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneLivraison> LigneLivraisons { get; set; }

        public virtual PanierCommande PanierCommande { get; set; }
    }
}
