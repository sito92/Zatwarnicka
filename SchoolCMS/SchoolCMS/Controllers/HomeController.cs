using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Helpers;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;
using PagedList;

namespace SchoolCMS.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index(int pageNumber=1)
        {
            int pageSize = context.CmsSettings.Select(x => x.NewsAmountPerSite).FirstOrDefault();
            var test = new MainPage
            {
                NewsList = context.InformationSources.OfType<News>().ToList(),
                ShortContentDict = new Dictionary<News, string>(),
            };

            NewsContentHelper.ContentTrimmer(test);
            test.PagedNews = test.ShortContentDict.Keys.ToPagedList(pageNumber, pageSize);
            return View(test);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
