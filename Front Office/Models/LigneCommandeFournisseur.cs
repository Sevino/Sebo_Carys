namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LigneCommandeFournisseur")]
    public partial class LigneCommandeFournisseur
    {
        public int QuantiteCommandeFournisseur { get; set; }

        public double PrixUnitaireFournisseur { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumeroCommandeFournisseur { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reference { get; set; }

        public virtual Article Article { get; set; }

        public virtual CommandeFournisseur CommandeFournisseur { get; set; }
    }
}
