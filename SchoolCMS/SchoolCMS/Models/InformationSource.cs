using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolCMS.Models
{
    public class InformationSource
    {
        public InformationSource()
        {
            Files = new List<File>();
        }
        public int Id { get; set; }

        public virtual User Author { get; set; }

        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }


        public DateTime Date { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Zawartość jest wymagana")]
        [Display(Name = "Zawartość")]
        public string Content { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}