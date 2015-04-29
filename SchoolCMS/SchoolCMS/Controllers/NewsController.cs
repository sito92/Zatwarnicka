﻿using System;
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

        public ActionResult NewsList()
        {
            var news = context.InforamtionSources.OfType<News>();

            return View(news);
        }

        public ActionResult NewsAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewsAdd(News model)
        {
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                context.InforamtionSources.Add(model);
                context.SaveChanges();

                return RedirectToAction("NewsList", "News");
            }

            return View(model);
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

            return RedirectToAction("NewsList","News");
        }

        public ActionResult NewsDelete(int newsId)
        {
            var selectedNews = context.InforamtionSources.OfType<News>().FirstOrDefault(x => x.Id == newsId);

            context.InforamtionSources.Remove(selectedNews);
            context.SaveChanges();

            return View("NewsList");
        }
    }
}
