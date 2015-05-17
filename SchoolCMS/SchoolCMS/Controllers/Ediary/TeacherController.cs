using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SchoolCMS.Models.EDiary;
using SchoolCMS.Models;
using WebMatrix.WebData;

namespace SchoolCMS.Controllers.Ediary
{
    public class TeacherController : BaseController
    {


        //
        // GET: /Teacher/

        public ActionResult Index()
        {
            return View(context.Users.OfType<Teacher>().ToList());
        }

        //
        // GET: /Teacher/Details/5

        public ActionResult Details(int id = 0)
        {
            Teacher teacher = context.Users.OfType<Teacher>().FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        //
        // GET: /Teacher/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teacher/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherModels.TeacherRegisterModel teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(teacher.UserName, teacher.Password, new
                    {
                        Discriminator = "Teacher",
                        Name = teacher.Name,
                        Surname = teacher.Surname,
                        Email = teacher.Email,
                    });
                    Roles.AddUserToRole(teacher.UserName, "Teacher");
                    return RedirectToAction("Index", "Teacher");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            ViewBag.ClassId = new SelectList(context.Classes, "Id", "Name");

            return View(teacher);
        }

        //
        // GET: /Teacher/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Teacher teacher = context.Users.OfType<Teacher>().FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        //
        // POST: /Teacher/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                context.Entry(teacher).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        //
        // GET: /Teacher/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Teacher teacher = context.Users.OfType<Teacher>().FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        //
        // POST: /Teacher/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = context.Users.OfType<Teacher>().FirstOrDefault(x => x.Id == id);
            context.Users.Remove(teacher);
            context.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult ChangePassword(TeacherModels.ChangeTeacherPassword model)
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
                        return RedirectToAction("Index", new { Message = CopyWriterController.ManageMessageId.ChangePasswordSuccess });
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

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return
                        "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}