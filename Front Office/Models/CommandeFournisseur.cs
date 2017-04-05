namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommandeFournisseur")]
    public partial class CommandeFournisseur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommandeFournisseur()
        {
            LigneCommandeFournisseurs = new HashSet<LigneCommandeFournisseur>();
        }

        [Key]
        public int NumeroCommandeFournisseur { get; set; }

        public DateTime DateCommandeFournisseur { get; set; }

        public int IdFournisseur { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneCommandeFournisseur> LigneCommandeFournisseurs { get; set; }
    }
}
