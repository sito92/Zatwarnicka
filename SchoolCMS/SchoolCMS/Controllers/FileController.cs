﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SchoolCMS.Models;
using WebMatrix.WebData;
using File = SchoolCMS.Models.File;

namespace SchoolCMS.Controllers
{
    [Authorize(Roles = "Administrator, Copywriter")]
    public class FileController : BaseController
    {
        //
        // GET: /File/
        private const string filesDirectory = "~/App_Data/Uploads/";

        [Authorize]
        public ActionResult List()
        {
            IQueryable<File> files;
            if (Roles.IsUserInRole("Administrator"))
            {
                files = context.Files;
            }
            else
            {
                var userId = WebSecurity.GetUserId(User.Identity.Name);
                files = context.Files.Where(x => x.AuthorId == userId);
            }

            return View(files);
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(File model,HttpPostedFileBase file)
        {
            if (file==null||file.ContentLength<=0)
            {
                ModelState.AddModelError(string.Empty,"Nie wybrano pliku");
                return View(model);

            }
            if (!ModelState.IsValid) return View(model);

            var extension = Path.GetExtension(file.FileName);
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);

            if (context.Files.Select(x=>x.FileName).Contains(fileName))
            {
                ModelState.AddModelError(string.Empty, "Plik o takiej nazwie już istnieje");
                return View(model);
            }
            if (context.FileExtensions.Select(x=>x.Extension).Contains(extension))
            {

                model.Extension = extension;
                model.FileType = context.FileExtensions.Where(x => x.Extension == extension).Select(x => x.FileType).FirstOrDefault();
                model.Size = file.ContentLength;
                model.UploadDateTime = DateTime.Now;
                model.FileName = fileName;

                model.AuthorId = WebSecurity.CurrentUserId; 

                file.SaveAs(GetFilePath(model));
                context.Files.Add(model);
                context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nie obsługiwane rozszerzenie");
                return View(model);
            }

            return RedirectToAction("List");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            var file = context.Files.FirstOrDefault(x => x.Id == id);
            if (file == null) return HttpNotFound();

            if (System.IO.File.Exists(GetFilePath(file)))
            {
                System.IO.File.Delete(GetFilePath(file));
            }
            context.Files.Remove(file);
            context.SaveChanges();
            return RedirectToAction("List");
        }
        [AllowAnonymous]
        public ActionResult Download(int id)
        {
            var file = context.Files.FirstOrDefault(x => x.Id == id);
            if (file==null)
            {
                return HttpNotFound();
            }
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(file.FilePath));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file.FileName + file.Extension);
        }
        private string GetFilePath(File file)
        {
            return Path.Combine(Server.MapPath(filesDirectory), file.FileName + file.Extension);
            
        }

    }
}
