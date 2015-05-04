﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
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
            if (filesToRemove != null)
            {
                var contextFilesToRemove = context.Files.Where(x => filesToRemove.Contains(x.Id));

                foreach (var fileToRemove in contextFilesToRemove)
                {
                    if (prePage.Files.Contains(fileToRemove))
                    {
                        prePage.Files.Remove(fileToRemove);
                    }
                }
            }
            if (filesToAdd != null)
            {
                var contextFilesToAdd = context.Files.Where(x => filesToAdd.Contains(x.Id));

                if (contextFilesToAdd.Any())
                {
                    foreach (var fileToAdd in contextFilesToAdd)
                    {
                        if (!prePage.Files.Contains(fileToAdd))
                        {
                            prePage.Files.Add(fileToAdd);
                        }
                    }
                }
            }

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
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Page page)
        {
            if (ModelState.IsValid)
            {
                var author = context.Users.FirstOrDefault(x => x.Username == WebSecurity.CurrentUserName);
                page.AuthorId = author.Id;
                page.Date = DateTime.Now;               
                context.InformationSources.Add(page);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(page);
        }
        protected void PopulateFiles(object selectedFile = null)
        {
            var files = context.Files.ToList();

            ViewBag.Files = new SelectList(files, "Id", "Name", selectedFile ?? 1);
        }

    }
}
