namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LigneLivraison")]
    public partial class LigneLivraison
    {
        public int QuantiteLivraison { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumeroLivraison { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reference { get; set; }

        public virtual Article Article { get; set; }

        public virtual Livraison Livraison { get; set; }
    }
}
