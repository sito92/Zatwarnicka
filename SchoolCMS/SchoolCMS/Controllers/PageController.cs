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
            return View(context.InforamtionSources.OfType<Page>());
        }

        public ActionResult Edit(int id)
        {
            var page = context.InforamtionSources.OfType<Page>().FirstOrDefault(x => x.Id == id);
            if (page == null)
                return HttpNotFound();
            PopulateFiles();
            return View(page);

        }
        [HttpPost]
        public ActionResult Edit(Page page,IEnumerable<int> filesId )
        {

            var prePage = context.InforamtionSources.OfType<Page>().FirstOrDefault(x => x.Id == page.Id);
            if (prePage==null)
            {
                return HttpNotFound();
            }

            
           
            return View();
        }

        public ActionResult Show(int id)
        {
            var page = context.InforamtionSources.OfType<Page>().FirstOrDefault(x => x.Id == id);
            if (page == null)
                return HttpNotFound();

            return View(page);
        }

        protected void PopulateFiles(object selectedFile = null)
        {
            var files = context.Files.ToList();

            ViewBag.Files = new SelectList(files, "Id", "Name", selectedFile ?? 1);
        }

    }
}
