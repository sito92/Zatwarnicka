using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models;

namespace SchoolCMS.Helpers
{
    public static class NewsPaginationHelper
    {
        public static Dictionary<News, int> PaginateNews(List<News> newsToPaginate)
        {
            var paginationDictionary = new Dictionary<News, int>();
            int pageNumber = 1;

            foreach (var news in newsToPaginate)
            {
                paginationDictionary.Add(news,pageNumber);
                
                if (newsToPaginate.IndexOf(news) % 4 == 0 && newsToPaginate.IndexOf(news) > 0)
                    pageNumber++;
            }

            return paginationDictionary;
        }
    }
}