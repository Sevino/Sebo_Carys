namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paiement")]
    public partial class Paiement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paiement()
        {
            PanierCommandes = new HashSet<PanierCommande>();
        }

        [Key]
        public int IdPaiement { get; set; }

        public double MontantPaiement { get; set; }

        [Required]
        [StringLength(200)]
        [Index(IsUnique = true)]
        public string ModePaiement { get; set; }

        public int NumeroCommande { get; set; }

        public virtual PanierCommande PanierCommande { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PanierCommande> PanierCommandes { get; set; }
    }
}
