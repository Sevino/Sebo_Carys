namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Acteur")]
    public partial class Acteur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acteur()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        public int IdActeur { get; set; }

        [Required]
        [StringLength(200)]
        public string NomActeur { get; set; }

        public int IdRoleActeur { get; set; }

        public virtual RoleActeur RoleActeur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
