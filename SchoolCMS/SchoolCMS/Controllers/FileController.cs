using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using File = SchoolCMS.Models.File;

namespace SchoolCMS.Controllers
{
    public class FileController : BaseController
    {
        //
        // GET: /File/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(context.Files);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(File file,IEnumerable<HttpPostedFileBase> files )
        {
            if (files.Any())
            {
                foreach (var fl in files)
                {
                    if (fl.ContentLength > 0)
                    {
                        var modelFile = new File()
                        {
                            UploadDateTime = DateTime.Now,
                            Extension = System.IO.Path.GetExtension(file.FileName),



                        };
                    }
                    fl.SaveAs("");
                }
            }
            return View();
        }

    }
}
