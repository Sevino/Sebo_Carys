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
        [Key]
        public int IdPaiement { get; set; }

        public double MontantPaiement { get; set; }

        [Required]
        [StringLength(200)]
        public string ModePaiement { get; set; }

        public int NumeroCommande { get; set; }

        public virtual PanierCommande PanierCommande { get; set; }
    }
}
