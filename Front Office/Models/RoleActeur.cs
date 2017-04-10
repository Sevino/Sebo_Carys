namespace Front_Office.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleActeur")]
    public partial class RoleActeur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoleActeur()
        {
            Acteurs = new HashSet<Acteur>();
        }

        [Key]
        public int IdRoleActeur { get; set; }

        [Required]
        [StringLength(200)]
        public string LibelleRoleActeur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acteur> Acteurs { get; set; }
    }
}
