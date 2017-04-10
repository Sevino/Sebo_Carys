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
        [Key]
        public int NumeroClient { get; set; }

        [Required(ErrorMessage = "Votre nom doit �tre saisi")]
        [StringLength(250)]
        [Display(Name = "Nom")]
        public string NomClient { get; set; }

        [Required(ErrorMessage = "Votre pr�nom doit �tre saisi")]
        [StringLength(250)]
        [Display(Name = "Pr�nom")]
        public string PrenomClient { get; set; }

        [Required(ErrorMessage = "Votre adresse doit �tre saisie")]
        [StringLength(250)]
        [Display(Name = "Adresse")]
        public string AdresseClient { get; set; }

        [Required(ErrorMessage = "Votre code postal doit �tre saisi")]
        [StringLength(5)]
        [RegularExpression("^((0[1-9])|([1-8][0-9])|(9[0-8])|(2A)|(2B))[0-9]{3}$", ErrorMessage = "Le code postal est incorrect")]
        [Display(Name = "Code Postal")]
        public string CodePostalClient { get; set; }

        [Required(ErrorMessage = "Votre ville doit �tre saisie")]
        [StringLength(250)]
        [Display(Name = "Ville")]
        public string VilleClient { get; set; }

        [Required(ErrorMessage = "Votre email doit �tre saisi")]
        [StringLength(250)]
        [Index(IsUnique = true)]
        [Display(Name = "Email")]
        public string EmailClient { get; set; }

        [Required(ErrorMessage = "Votre num�ro de t�l�phone doit �tre saisi")]
        [StringLength(10)]
        [Display(Name = "Num�ro de t�l�phone")]
        public string TelephoneClient { get; set; }

        [Required(ErrorMessage = "Votre mot de passe doit �tre saisi")]
        [StringLength(250)]
        [Display(Name = "Mot de passe")]
        public string MotDePasseClient { get; set; }
    }
}
