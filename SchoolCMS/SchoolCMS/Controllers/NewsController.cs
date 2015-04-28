using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;

namespace SchoolCMS.Controllers
{
    public class NewsController : BaseController
    {
        
        public ActionResult NewsDetails(int newsId)
        {
            var selectedNews = context.InforamtionSources.OfType<News>().FirstOrDefault(x => x.Id == newsId);

            return View(selectedNews);
        }

        public ActionResult NewsEdit(int newsId)
        {

            var selectedNews = new NewsEdit
            {
                News = context.InforamtionSources.OfType<News>().FirstOrDefault(x => x.Id == newsId),
                Tags = new SelectList(context.Tags,"Id","Name"),
            };

            selectedNews.SelectedTags = selectedNews.News.Tags.Select(x => x.Id).ToList();

            return View(selectedNews);
        }

        [HttpPost]
        public ActionResult NewsEdit(NewsEdit model)
        {
            var selectedNews = context.InforamtionSources.OfType<News>().FirstOrDefault(x => x.Id == model.News.Id);
            var tags = context.Tags.Where(x => model.SelectedTags.Contains(x.Id));

            selectedNews.Tags.AddRange(tags);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
