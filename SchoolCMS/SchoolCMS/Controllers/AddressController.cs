using SchoolCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolCMS.Controllers
{
    public class AddressController : BaseController
    {

        [Authorize(Roles = "Administrator")]
        public ActionResult Add()
        {
            var model = new Address();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Add(Address model)
        {
            if (model != null && ModelState.IsValid)
            { 
                context.Addresses.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("List", "Address");
        }

        public ActionResult List()
        {
            var model = context.Addresses.ToList();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = context.Addresses.FirstOrDefault(x => x.Id == id);

            if (model != null)
            { 
                context.Addresses.Remove(model);
                context.SaveChanges();
            }

            return RedirectToAction("List", "Address");
        }

        public ActionResult Edit(int id)
        {
            return View(context.Addresses.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Address model)
        {
            var updatedModel = context.Addresses.FirstOrDefault(x => x.Id == model.Id);
            if (updatedModel == null)
                return HttpNotFound();

            if(ModelState.IsValid)
            { 
            updatedModel.Name = model.Name;
            updatedModel.PostCode = model.PostCode;
            updatedModel.HouseNumber = model.HouseNumber;
            updatedModel.Street = model.Street;
            updatedModel.City = model.City;

            context.SaveChanges();
            }

            return RedirectToAction("Edit", "CmsSettings");
        }
    }
}
