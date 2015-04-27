using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected CmsContext context = new CmsContext();
        public BaseController()
        {
            var settings = GetSettings();
            ViewBag.Settings = settings;
        }

        protected CmsSettings GetSettings()
        {
            var settings = context.CmsSettings.FirstOrDefault();

            return settings;
        }
    }
}
