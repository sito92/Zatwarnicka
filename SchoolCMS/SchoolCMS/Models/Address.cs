using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Miejscowość jest wymagana")]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Required(ErrorMessage = "Nazwa ulicy jest wymagana")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Range(1, 150, ErrorMessage = "Wpisz liczbę w zakresie {1}-{2}")]
        [Required(ErrorMessage = "Numer domu jest wymagany")]
        [Display(Name = "Nr budynku")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [Display(Name = "Kod pocztowy")]
        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }
    }
}