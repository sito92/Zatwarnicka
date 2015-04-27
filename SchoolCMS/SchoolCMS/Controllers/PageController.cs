using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.Controllers
{
    public class PageController : BaseController
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(context.Pages);
        }

        public ActionResult Edit(int id)
        {
            var page = context.Pages.FirstOrDefault(x => x.Id == id);
            if (page == null)
                return HttpNotFound();

            return View(page);

        }

        public ActionResult Show(int id)
        {
            var page = context.Pages.FirstOrDefault(x => x.Id == id);
            if (page == null)
                return HttpNotFound();

            return View(page);
        }

    }
}
