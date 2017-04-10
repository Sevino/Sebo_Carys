namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockArticle")]
    public partial class StockArticle
    {
        [Key]
        public int IdStock { get; set; }

        public int Quantite { get; set; }

        public int QuantiteReserve { get; set; }

        public int? Seuil { get; set; }

        public int Reference { get; set; }

        public virtual Article Article { get; set; }
    }
}
