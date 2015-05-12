using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolCMS.ViewModels
{
    public class RichCmsSettings
    {

        [Required(ErrorMessage = "Nazwa szkoły jest wymagana")]
        [Display(Name = "Nazwa szkoły")]
        public string SchoolName { get; set; }

        [Range(1, 12, ErrorMessage = "Wpisz liczbę w zakresie {1}-{2}")]
        [Required(ErrorMessage = "Ilość newsów na stronę")]
        [Display(Name = "Newsy na stronę")]
        public int NewsAmountPerSite { get; set; }

       
        public int SelectedLayoutId { get; set; }

        [Required(ErrorMessage = "Layout jest wymagany")]
        [Display(Name = "Szaty graficzne")]
        public IEnumerable<SelectListItem> Layouts { get; set; }

        
        //public int SelectedAddressId { get; set; }

        //[Required(ErrorMessage = "Adres jest wymagany")]
        //[Display(Name = "Adres szkoły")]
        //public IEnumerable<SelectListItem> Addresses { get; set; }
        [Display(Name = "Adres")]
        public Address Address { get; set; }

        public int SelectedLogoSettingsId { get; set; }

        public IEnumerable<SelectListItem> LogoSettings { get; set; } 
    }
}