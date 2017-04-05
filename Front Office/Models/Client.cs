namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            PanierCommandes = new HashSet<PanierCommande>();
        }

        [Key]
        public int NumeroClient { get; set; }

        [Required]
        [StringLength(250)]
        public string NomClient { get; set; }

        [Required]
        [StringLength(250)]
        public string PrenomClient { get; set; }

        [Required]
        [StringLength(250)]
        public string AdresseClient { get; set; }

        [Required]
        [StringLength(5)]
        public string CodePostalClient { get; set; }

        [Required]
        [StringLength(250)]
        public string VilleClient { get; set; }

        [Required]
        [StringLength(250)]
        [Index(IsUnique = true)]
        [Display(Name = "Email")]
        public string EmailClient { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Mot de passe")]
        public string MotDePasseClient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PanierCommande> PanierCommandes { get; set; }
    }
}
