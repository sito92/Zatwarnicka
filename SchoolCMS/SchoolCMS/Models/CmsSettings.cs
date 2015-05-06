using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class CmsSettings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Layout jest wymagany")]
        [Display(Name = "Layout")]
        public int LayoutId{ get; set; }
        
        [Required(ErrorMessage="Nazwa szkoły jest wymagana")]
        [Display(Name = "Nazwa szkoły")]
        public string SchoolName { get; set; }

        public virtual Layout Layout{ get; set; }
        
        public virtual Address Address {get; set;}

        [Required(ErrorMessage = "Adres jest wymagany")]
        [Display(Name = "Adres szkoły")]
        public int AdressId { get; set; }

        [Range(1, 12, ErrorMessage = "Wpisz liczbę w zakresie {1}-{2}")]
        [Required(ErrorMessage = "Ilość newsów na stronę")]
        [Display(Name = "Newsy na stronę")]
        public int NewsAmountPerSite {get; set;}


        public virtual LogoSettings LogoSettings {get; set;}
        public int? LogoSetingsId { get; set; }
    }
}