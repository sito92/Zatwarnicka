using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.ViewModels
{
    public class NewsEdit  
    {
        public News News { get; set; }

        public List<int> SelectedTags { get; set; }

        public IEnumerable<SelectListItem> Tags { get; set; } 
    }
}