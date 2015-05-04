using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using SchoolCMS.Models;

namespace SchoolCMS.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { Discriminator = "CopyWriter", Name = model.Name, Surname = model.Surname, Email = model.Email });
                    Roles.AddUserToRole(model.UserName, "CopyWriter");
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ChangePersonalData(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                 message == ManageMessageId.ChangePersonalDataSuccess ? "Dane zostały zmienione."
                : "";
            ViewBag.ReturnUrl = Url.Action("ChangePersonalData");
            return View();
        }
        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePersonalData(ChangePersonalDataModel model)
        {
            ViewBag.ReturnUrl = Url.Action("ChangePersonalData");

            if (ModelState.IsValid)
            {
                if (WebSecurity.IsConfirmed(model.UserName))
                {
                    bool changePersonalDataSucceeded = true;
                   
                        var id = WebSecurity.GetUserId(model.UserName);

                    if (model.Email != null)
                    {
                        try
                        {
                           var user = context.Users.FirstOrDefault(x => x.Id == id);
                           user.Email = model.Email;
                           context.SaveChanges();
                        }
                        catch (Exception)
                        {
                             changePersonalDataSucceeded = false;
                             ModelState.AddModelError("", "Nie udało się zmienić adresu email");
                        }
                       
                    }
                    if (model.Name != null)
                    {
                         try
                        {
                            var user = context.Users.FirstOrDefault(x => x.Id == id);
                            user.Name = model.Name;
                            context.SaveChanges();
                        }
                        catch (Exception)
                        {
                             changePersonalDataSucceeded = false;
                             ModelState.AddModelError("", "Nie udało się zmienić imienia");
                        }

                    }
                    if (model.Surname != null)
                    {
                        try
                        {
                            var user = context.Users.FirstOrDefault(x => x.Id == id);
                            user.Surname = model.Surname;
                            context.SaveChanges();
                        }
                        catch (Exception)
                        {
                             changePersonalDataSucceeded = false;
                             ModelState.AddModelError("", "Nie udało się zmienić nazwiska");
                        }

                    }
                    if (changePersonalDataSucceeded)
                    {
                        return RedirectToAction("ChangePersonalData", new { Message = ManageMessageId.ChangePersonalDataSuccess }); 
                    }
                    }
                else
                {
                    ModelState.AddModelError("", "Podany CopyWiter nie istnieje");
                }

            }

            return View(model);
        }

        public ActionResult ChangePassword(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Hasło zostało zmienione."
               : "";
            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            return View();
        }
        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
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
                        return RedirectToAction("ChangePassword", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "No kurde błąd");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Podany CopyWiter nie istnieje");
                }

            }

            return View(model);
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            ChangePersonalDataSuccess
        }

 private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

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
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
