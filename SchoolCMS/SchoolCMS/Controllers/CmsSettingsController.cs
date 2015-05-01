using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

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
            PopulateLayouts(settings.LayoutId);
            return View(settings);
        }

        [HttpPost]
        public ActionResult Edit(CmsSettings settings)
        {
            var presettings = context.CmsSettings.FirstOrDefault();

            presettings.LayoutId = settings.LayoutId;
            presettings.SchoolName = settings.SchoolName;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        private void PopulateLayouts(object selectedLayout = null)
        {
            var layouts = context.Layouts.OrderBy(x => x.Id).ToList();

            ViewBag.Layouts = new SelectList(layouts, "Id", "Name", selectedLayout ?? 0);
        }
        
    }
}
