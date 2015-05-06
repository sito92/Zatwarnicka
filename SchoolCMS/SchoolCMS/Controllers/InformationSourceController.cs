using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.Controllers
{
    public class InformationSourceController : BaseController
    {
        //
        // GET: /InoframtionSource/
        private const string pageClassName = "Page";
        private const string newsClassName = "News";
        public ActionResult Show(int id)
        {

            var informationSource = context.InformationSources.FirstOrDefault(x => x.Id == id);

            if (informationSource==null)
            {
                return HttpNotFound();
            }

            return GetClassName(informationSource) == pageClassName ? RedirectToAction("Show", "Page", new { id = id }) : RedirectToAction("Details", "News", new { newsid = id });
        }

        private string GetClassName<T>(T className)
        {
            var name = className.GetType().Name;
            int index = name.IndexOf("_");
            if (index > 0)
                name = name.Substring(0, index);
            return name;
        }


    }
}
