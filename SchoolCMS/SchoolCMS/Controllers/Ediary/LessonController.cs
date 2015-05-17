using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models.EDiary;
using SchoolCMS.Models;
using WebMatrix.WebData;

namespace SchoolCMS.Controllers.Ediary
{
    public class LessonController : BaseController
    {
        //
        // GET: /Lesson/

        public ActionResult Index()
        {
            var lessons = context.Lessons.Include(l => l.Class).Include(l => l.Subject);
            return View(lessons.ToList());
        }

        //
        // GET: /Lesson/Details/5

        public ActionResult Details(int id = 0)
        {
            Lesson lesson = context.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        //
        // GET: /Lesson/Create

        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name");
            ViewBag.SubjectId = new SelectList(context.Subjects, "Id", "Name");
            return View();
        }

        //
        // POST: /Lesson/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                var teacher = context.Teachers.FirstOrDefault(x => x.Username == WebSecurity.CurrentUserName);
                if(teacher !=null)
                { 
                lesson.TeacherId = teacher.Id;
                context.Lessons.Add(lesson);
                context.SaveChanges();
                return RedirectToAction("Index", "Lesson");
                }
            }

            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name", lesson.ClassId);
            ViewBag.SubjectId = new SelectList(context.Subjects, "Id", "Name", lesson.SubjectId);
            return View(lesson);
        }

        //
        // GET: /Lesson/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Lesson lesson = context.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name", lesson.ClassId);
            ViewBag.SubjectId = new SelectList(context.Subjects, "Id", "Name", lesson.SubjectId);
            return View(lesson);
        }

        //
        // POST: /Lesson/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                context.Entry(lesson).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name", lesson.ClassId);
            ViewBag.SubjectId = new SelectList(context.Subjects, "Id", "Name", lesson.SubjectId);
            return View(lesson);
        }

        //
        // GET: /Lesson/Delete/5

        public ActionResult Delete(Lesson lesson)
        {
            
            if (context.Lessons.FirstOrDefault(x => x.Id == lesson.Id) == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        //
        // POST: /Lesson/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = context.Lessons.Find(id);
            context.Lessons.Remove(lesson);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}