using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using SchoolCMS.Helpers;
using SchoolCMS.Models;
using WebGrease.Css.Extensions;
using WebMatrix.WebData;

namespace SchoolCMS.Controllers
{
    public class PageController : BaseController
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult List()
        {
            return View(context.InformationSources.OfType<Page>());
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var page = context.InformationSources.OfType<Page>().FirstOrDefault(x => x.Id == id);
            if (page == null)
                return HttpNotFound();
            PopulateFiles();
            return View(page);

        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(Page page, IEnumerable<int> filesToAdd, IEnumerable<int> filesToRemove)
        {
            if (!ModelState.IsValid)
            {
                return View(page);
            }
            var prePage = context.InformationSources.OfType<Page>().FirstOrDefault(x => x.Id == page.Id);
            if (prePage == null)
            {
                return HttpNotFound();
            }

            prePage.ManageFiles(filesToRemove, filesToAdd,context);

            prePage.Content = page.Content;
            prePage.Title = page.Title;

            context.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Show(int id)
        {
            var page = context.InformationSources.OfType<Page>().FirstOrDefault(x => x.Id == id);
            if (page == null)
                return HttpNotFound();

            return View(page);
        }

        [Authorize]
        public ActionResult Create()
        {
            PopulateFiles();
            return View(new Page());
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Page page, IEnumerable<int> filesToAdd, IEnumerable<int> filesToRemove)
        {
            if (ModelState.IsValid)
            {
                var author = context.Users.FirstOrDefault(x => x.Username == WebSecurity.CurrentUserName);
                page.AuthorId = author.Id;
                page.Date = DateTime.Now;
                page.ManageFiles(filesToRemove, filesToAdd,context);
                context.InformationSources.Add(page);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(page);
        }

        public ActionResult Delete(int id)
        {
            var page = context.InformationSources.OfType<Page>().FirstOrDefault(x => x.Id == id);

            if (page != null)
                context.InformationSources.Remove(page);
            
            context.SaveChanges();

            return RedirectToAction("List");
        }
        protected void PopulateFiles(object selectedFile = null)
        {
            var files = context.Files.ToList();

            ViewBag.Files = new SelectList(files, "Id", "Name", selectedFile ?? 1);
        }

    }
}
