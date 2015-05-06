using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class FileExtension
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Rozszerzenie jest wymagane")]
        [Display(Name = "Rozszerzenie")]
        public string Extension { get; set; }

        public int FileTypeId { get; set; }
        public virtual FileType FileType { get; set; }
    }
}