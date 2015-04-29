using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models;

namespace SchoolCMS.ViewModels
{
    public class MainPage
    {
        public List<News> NewsList { get; set; }

        public Dictionary<News, string> ShortContentDict { get; set; }
    }
}