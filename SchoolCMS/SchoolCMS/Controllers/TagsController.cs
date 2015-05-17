using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.Controllers
{
    public class TagsController : BaseController
    {

        //
        // GET: /Tags/

        public ActionResult List()
        {
            return View(context.Tags.ToList());
        }

        //
        // GET: /Tags/Details/5

        public ActionResult Details(int id = 0)
        {
            Tag tag = context.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // GET: /Tags/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tags/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                return RedirectToAction("List", "Tags");
            }

            return View(tag);
        }

        //
        // GET: /Tags/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tag tag = context.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Tags/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tag).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("List","Tags");
            }
            return View(tag);
        }

        //
        // GET: /Tags/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tag tag = context.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Tags/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = context.Tags.Find(id);
            context.Tags.Remove(tag);
            context.SaveChanges();
            return RedirectToAction("List", "Tags");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}