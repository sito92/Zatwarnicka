using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;
using WebMatrix.WebData;

namespace SchoolCMS.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class NewsController : BaseController
    {
        [AllowAnonymous]
        public ActionResult NewsDetails(int newsId)
        {
            var selectedNews = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == newsId);

            return View(selectedNews);
        }
        [Authorize]
        public ActionResult List()
        {
            var news = context.InformationSources.OfType<News>();

            return View(news);
        }
        [Authorize]
        public ActionResult Add()
        {
            var news = new NewsEdit
            {
                Tags = new SelectList(context.Tags, "Id", "Name"),
                News = new News()
            };
            news.News.Files = context.Files.ToList();
            PopulateFiles();

            return View(news);
        }

        [HttpPost]
        public ActionResult Add(NewsEdit model)
        {
            //if (ModelState.IsValid)
            //{
                var author = context.Users.FirstOrDefault(x => x.Username == WebSecurity.CurrentUserName);
                model.News.AuthorId = author.Id;
                model.News.Date = DateTime.Now;
                model.News.Tags = context.Tags.Where(x => model.SelectedTags.Contains(x.Id)).ToList();

                context.InformationSources.Add(model.News);
                context.SaveChanges();

                return RedirectToAction("List", "News");
            //}
        }

        public ActionResult Edit(int newsId)
        {

            var selectedNews = new NewsEdit
            {
                News = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == newsId),
                Tags = new SelectList(context.Tags,"Id","Name"),
            };

            selectedNews.SelectedTags = selectedNews.News.Tags.Select(x => x.Id).ToList();

            return View(selectedNews);
        }

        [HttpPost]
        public ActionResult Edit(NewsEdit model)
        {
            var selectedNews = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == model.News.Id);
            var tags = context.Tags.Where(x => model.SelectedTags.Contains(x.Id));

            selectedNews.Tags.AddRange(tags);
            context.SaveChanges();

            return RedirectToAction("List","News");
        }

        public ActionResult Delete(int newsId)
        {
            var selectedNews = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == newsId);

            context.InformationSources.Remove(selectedNews);
            context.SaveChanges();

            return View("List");
        }

        protected void PopulateFiles(object selectedFile = null)
        {
            var files = context.Files.ToList();

            ViewBag.Files = new SelectList(files, "Id", "Name", selectedFile ?? 1);
        }
    }
}
