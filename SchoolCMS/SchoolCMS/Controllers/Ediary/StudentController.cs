using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SchoolCMS.Helpers;
using SchoolCMS.Models.EDiary;
using SchoolCMS.Models;
using WebMatrix.WebData;

namespace SchoolCMS.Controllers.Ediary
{
    public class StudentController : BaseController
    {
        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = context.Users.OfType<Student>().FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name");
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentRegisterModel student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(student.UserName, student.Password, new { Discriminator = "Student", 
                                                                                           Name = student.Name, 
                                                                                           Surname = student.Surname, 
                                                                                           Email = student.Email, 
                                                                                           });
                    Roles.AddUserToRole(student.UserName, "Student");
                    return RedirectToAction("List", "Student");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", LoginMessagesHelper.ErrorCodeToString(e.StatusCode));
                }
            }

            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name");
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = context.Users.OfType<Student>().FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name", student.ClassId);
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Entry(student).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name", student.ClassId);
            return View(student);
        }

        public ActionResult Dashboard()
        {
            var currentStudent = context.Students.FirstOrDefault(x => x.Username == WebSecurity.CurrentUserName);
            return View(currentStudent);
        }

        public ActionResult Grades(Lesson lesson)
        {
            var currentStudent = context.Students.FirstOrDefault(x => x.Username == WebSecurity.CurrentUserName);
            if (currentStudent == null)
            {
                return HttpNotFound();
            }

            var grades = currentStudent.Grades.Where(x => x.LessonId == lesson.Id);
            
            return View(grades);
        }

        public ActionResult ChangePassword(CopyWriterController.ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == CopyWriterController.ManageMessageId.ChangePasswordSuccess ? "Hasło zostało zmienione."
               : "";
            ViewBag.ReturnUrl = Url.Action("List");
            return View();
        }
        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangeStudentPassword model)
        {
            ViewBag.ReturnUrl = Url.Action("ChangePassword");

            if (ModelState.IsValid)
            {
                if (WebSecurity.IsConfirmed(model.UserName))
                {
                    bool changePasswordSucceeded = true;
                    try
                    {
                        WebSecurity.ResetPassword(WebSecurity.GeneratePasswordResetToken(model.UserName),
                            model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("List", new { Message = CopyWriterController.ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "No kurde błąd");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Podany uczeń nie istnieje");
                }

            }

            return View(model);
        }
        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = context.Users.OfType<Student>().FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = context.Users.OfType<Student>().FirstOrDefault(x => x.Id == id);
            context.Users.Remove(student);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var students = context.Users.OfType<Student>();

            return View(students);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}