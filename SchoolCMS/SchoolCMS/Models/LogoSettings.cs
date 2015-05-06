using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class LogoSettings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa logo jest wymagana")]
        [Display(Name = "Nazwa")]
        public string LogoName { get; set; }

        [Required(ErrorMessage = "Ścieżka logo jest wymagana")]
        [Display(Name = "Ścieżka logo")]
        public string LogoPath { get; set; }
    }
}