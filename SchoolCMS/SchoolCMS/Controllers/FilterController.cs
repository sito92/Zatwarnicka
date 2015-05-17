using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.Controllers
{
    public class FilterController : BaseController
    {
        //
        // GET: /Filter/

        public ActionResult Filter(string Tag)
        {
            var tag = context.Tags.FirstOrDefault(x => x.Name == Tag);
            var matchingNewses = context.InformationSources.OfType<News>().AsEnumerable().Where(x => x.Tags.Contains(tag));

            return View(matchingNewses);
        }

    }
}
