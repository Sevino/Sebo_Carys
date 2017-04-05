namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LigneCommande")]
    public partial class LigneCommande
    {
        public int QuantiteCommande { get; set; }

        public double PrixUnitaire { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumeroCommande { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reference { get; set; }

        public virtual Article Article { get; set; }

        public virtual PanierCommande PanierCommande { get; set; }
    }
}
