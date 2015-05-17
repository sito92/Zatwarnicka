using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SchoolCMS.Helpers;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;

namespace SchoolCMS.Controllers
{
    public class FilterController : BaseController
    {
        //
        // GET: /Filter/
        private char hashSplit = '#';
        public ActionResult Filter(string Tag, int pageNumber = 1)
        {
            var filtredNews = new List<News>();

            var tags = Tag.ToLower().Split(hashSplit).Where(x=>!string.IsNullOrEmpty(x));

            var contextTags = context.Tags.AsEnumerable().Where(x => tags.Contains(x.Name.ToLower()));

            foreach (var contextTag in contextTags)
            {
                var matchingTag =
                    context.InformationSources.OfType<News>().AsEnumerable().Where(x => x.Tags.Contains(contextTag)).Distinct();

                filtredNews.AddRange(matchingTag);
            }


            return View(filtredNews);
        }

    }
}
