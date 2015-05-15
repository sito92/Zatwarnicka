using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Helpers;
using SchoolCMS.Models.EDiary;
using SchoolCMS.ViewModels.EDiary.ClassViewModels;

namespace SchoolCMS.Controllers.EDiary
{
    public class ClassController : BaseController
    {
        //
        // GET: /Class/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var viewModel = new ClassListViewModel()
            {
                Classes = context.Classes.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Add()
        {
            var viewModel = new ClassViewModel()
            {
                Class = new Class(),
                AvaiableStudents = context.Users.OfType<Student>().ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ClassViewModel model, IEnumerable<int> studentsToRemove, IEnumerable<int> studentsToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var myClass =model.Class;
            myClass.ManageStudents(studentsToRemove,studentsToAdd,context);
            context.Classes.Add(myClass);
            context.SaveChanges();
            return RedirectToAction("List");

        }
        public ActionResult Edit(int id)
        {
            var myClass = context.Classes.FirstOrDefault(x => x.Id == id);
            if (myClass==null)
            {
                return HttpNotFound();
            }
            var viewModel = new ClassViewModel()
            {
                Class =myClass,
                AvaiableStudents = context.Users.OfType<Student>().ToList()
            };

            return View(viewModel);


        }

        [HttpPost]
        public ActionResult Edit(ClassViewModel model,IEnumerable<int> studentsToRemove,IEnumerable<int> studentsToAdd  )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var preClass = context.Classes.FirstOrDefault(x => x.Id == model.Class.Id);
            preClass.Name = model.Class.Name;
            preClass.ManageStudents(studentsToRemove, studentsToAdd,context);
            context.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult Delete(int id)
        {
            var myClass = context.Classes.FirstOrDefault(x => x.Id == id);
            if (myClass == null)
            {
                return HttpNotFound();
            }
            context.Classes.Remove(myClass);
            context.SaveChanges();
        }

    }
}
