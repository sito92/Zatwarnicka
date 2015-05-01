﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using SchoolCMS.Models;

namespace SchoolCMS.ViewModels
{
    public class MainPage
    {
        public List<News> NewsList { get; set; }

        public IPagedList<News> PagedNews { get; set; }

        public Dictionary<News, string> ShortContentDict { get; set; }
    }
}