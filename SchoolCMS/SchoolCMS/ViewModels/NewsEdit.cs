using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolCMS.ViewModels
{
    public class NewsEdit  
    {

        public News News { get; set; }

        [Display(Name = "Wybrane tagi")]
        public List<int> SelectedTags { get; set; }

        [Display(Name = "Tagi")]
        public IEnumerable<SelectListItem> Tags { get; set; } 
    }
}