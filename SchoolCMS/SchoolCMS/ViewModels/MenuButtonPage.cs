using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolCMS.ViewModels
{
    public class MenuButtonPage
    {

        public MenuButton MenuButton { get; set; }

        [Display(Name = "Wybrana strona")]
        public int SelectedPage { get; set; } 
       
        [Display(Name = "Strona podpięta do przycisku")]
        public IEnumerable<SelectListItem> Pages  { get; set; }
    }
}