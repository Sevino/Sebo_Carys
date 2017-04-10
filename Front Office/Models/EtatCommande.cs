namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EtatCommande")]
    public partial class EtatCommande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EtatCommande()
        {
            PanierCommandes = new HashSet<PanierCommande>();
        }

        [Key]
        public int IdEtat { get; set; }

        [Required]
        [StringLength(50)]
        public string LibelleEtat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PanierCommande> PanierCommandes { get; set; }
    }
}
