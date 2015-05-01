using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;

namespace SchoolCMS.Controllers
{
    public class CmsSettingsController : BaseController
    {
        //
        // GET: /CmsSettings/

        public ActionResult Edit()
        {
            var settings = GetSettings();
            if (settings == null)
            {
                return HttpNotFound();
            }

            var cmsSettings = new RichCmsSettings()
            {
                SchoolName = settings.SchoolName,
                NewsAmountPerSite = settings.NewsAmountPerSite,
                Layouts = new SelectList(context.Layouts, "Id", "Name"),
                Addresses = new SelectList(context.Addresses, "Id","Name"),
                LogoSettings = new SelectList(context.LogoSettings, "Id","LogoName")
            };

            return View(cmsSettings);
        }

        [HttpPost]
        public ActionResult Edit(RichCmsSettings settings)
        {
            var presettings = context.CmsSettings.FirstOrDefault();

            if (presettings == null)
                return RedirectToAction("Index", "Home");

            presettings.Address = context.Addresses.FirstOrDefault(x => x.Id == settings.SelectedAddressId);
            presettings.SchoolName = settings.SchoolName;
            presettings.NewsAmountPerSite = settings.NewsAmountPerSite;
            presettings.Layout = context.Layouts.FirstOrDefault(x => x.Id == settings.SelectedLayoutId);
            presettings.LogoSettings = context.LogoSettings.FirstOrDefault(x => x.Id == settings.SelectedLogoSettingsId);

            context.SaveChanges();
            
            return RedirectToAction("Index", "Home");

        }
    }
}
