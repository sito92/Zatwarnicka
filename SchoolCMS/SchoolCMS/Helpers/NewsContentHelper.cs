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
            foreach (var news in page.newsList)
            {
                if (news.Content.Length < 150)
                {
                    page.ShortContentDict.Add(news,news.Content);
                }
                else
                {
                    page.ShortContentDict.Add(news,news.Content.Substring(0,150));
                }
            }

            return page;
        }
    }
}