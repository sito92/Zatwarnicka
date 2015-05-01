using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;

namespace SchoolCMS.Helpers
{
    public static class NewsContentHelper
    {
        public static MainPage ContentTrimmer(MainPage page)
        {
            foreach (var news in page.NewsList)
            {
                page.ShortContentDict.Add(news,
                    news.Content.Length < 150 ? news.Content : news.Content.Substring(0, 150));
            }

            return page;
        }
    }
}