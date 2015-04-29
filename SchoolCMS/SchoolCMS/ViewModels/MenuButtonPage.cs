using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.ViewModels
{
    public class MenuButtonPage
    {
        public MenuButton MenuButton { get; set; }

        public List<int> SelectedPage { get; set; } 
       
        public IEnumerable<SelectListItem> Pages  { get; set; }
    }
}