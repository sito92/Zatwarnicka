using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class FileType
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Typ pliku jest wymagany")]
        [Display(Name = "Typ pliku")]
        public string Name { get; set; }
    }
}