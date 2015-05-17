using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Protocols;
using DotNetOpenAuth.Messaging;
using SchoolCMS.Helpers;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;
using WebMatrix.WebData;

namespace SchoolCMS.Controllers
{
    [Authorize(Roles = "Administrator, Copywriter")]
    public class NewsController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Details(int newsId)
        {
            var selectedNews = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == newsId);

            return View(selectedNews);
        }
        [Authorize]
        public ActionResult List()
        {
            IQueryable<News> newses;
            if (Roles.IsUserInRole("Administrator"))
            {
                 newses = context.InformationSources.OfType<News>();
            }
            else
            {
                var userId = WebSecurity.GetUserId(User.Identity.Name);
                newses = context.InformationSources.OfType<News>().Where(x => x.AuthorId == userId);
                
            }
            

            return View(newses);
        }
        [Authorize]
        public ActionResult Add()
        {
            var news = new NewsEdit
            {
                Tags = new SelectList(context.Tags, "Id", "Name"),
                News = new News()
            };
            PopulateFiles();

            return View(news);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Add(NewsEdit model,IEnumerable<int> filesToAdd, IEnumerable<int> filesToRemove)
        {
            if (model.SelectedTags==null || !model.SelectedTags.Any())
            {
                ModelState.AddModelError(string.Empty,"News musi mieć chociaż jeden tag");
                model.Tags = new SelectList(context.Tags, "Id", "Name");
                PopulateFiles();
            }
            if (ModelState.IsValid)
            {
                var author = context.Users.FirstOrDefault(x => x.Username == WebSecurity.CurrentUserName);
                model.News.AuthorId = author.Id;
                model.News.Date = DateTime.Now;
                model.News.Tags = context.Tags.Where(x => model.SelectedTags.Contains(x.Id)).ToList();
                model.News.ManageFiles(filesToRemove, filesToAdd,context);
                context.InformationSources.Add(model.News);
                context.SaveChanges();

                return RedirectToAction("List", "News");
            }
            
            PopulateFiles();
            return View(model);
        }

        public ActionResult Edit(int newsId)
        {
            if (context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == newsId).AuthorId != WebSecurity.GetUserId(User.Identity.Name) && !Roles.IsUserInRole("Administrator"))
            {
                return RedirectToAction("List", "News");
            }

            var selectedNews = new NewsEdit
            {
                News = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == newsId),
                Tags = new SelectList(context.Tags,"Id","Name"),
            };

            selectedNews.SelectedTags = selectedNews.News.Tags.Select(x => x.Id).ToList();
            PopulateFiles();
            return View(selectedNews);
        }

        [HttpPost]
        public ActionResult Edit(NewsEdit model, IEnumerable<int> filesToAdd, IEnumerable<int> filesToRemove)
        {

            if (model.SelectedTags == null || !model.SelectedTags.Any())
            {
                ModelState.AddModelError(string.Empty, "News musi mieć chociaż jeden tag");
                model.Tags = new SelectList(context.Tags, "Id", "Name");
            }
            if (!ModelState.IsValid)
            {
                PopulateFiles();
                return View(model);
            }
            var selectedNews = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == model.News.Id);
            if (selectedNews == null)
            {
                return HttpNotFound();
            }
            var tags = context.Tags.Where(x => model.SelectedTags.Contains(x.Id));
           selectedNews.ManageFiles(filesToRemove,filesToAdd,context);
            selectedNews.Tags.AddRange(tags);
            selectedNews.Content = model.News.Content;
            selectedNews.Title = model.News.Title;
            context.SaveChanges();

            return RedirectToAction("List","News");
        }

        
        public ActionResult Delete(int newsId)
        {
            var selectedNews = context.InformationSources.OfType<News>().FirstOrDefault(x => x.Id == newsId);
            if (selectedNews.AuthorId != WebSecurity.GetUserId(User.Identity.Name))
            {
               return RedirectToAction("List", "News");
            }

            context.InformationSources.Remove(selectedNews);
            context.SaveChanges();

            return RedirectToAction("List", "News");
        }

        protected void PopulateFiles(object selectedFile = null)
        {
            var files = context.Files.ToList();

            ViewBag.Files = new SelectList(files, "Id", "Name", selectedFile ?? 1);
        }
    }
}
