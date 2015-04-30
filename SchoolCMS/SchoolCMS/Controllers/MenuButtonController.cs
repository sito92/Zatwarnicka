using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;

namespace SchoolCMS.Controllers
{
    public class MenuButtonController : BaseController
    {

        //
        // GET: /MenuButton/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(context.MenuButtons.Where(x=>x.IsRootButton));
        }
        public ActionResult Edit(int menuButtonId)
        {
            var menuButton = context.MenuButtons.FirstOrDefault(x => x.Id == menuButtonId);

            if (menuButton==null)
            {
                return HttpNotFound();
            }
            PopulatePages(menuButton.InformationSourceId);
            return View("Edit",menuButton);
        }

        [HttpPost]
        public ActionResult Edit(MenuButton button)
        {
            var dbButton = context.MenuButtons.FirstOrDefault(x => x.Id == button.Id);
            if (dbButton==null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                if (button.InformationSourceId == 0)
                {
                    button.InformationSourceId = null;
                }
                dbButton.Name = button.Name;
                dbButton.InformationSourceId = button.InformationSourceId;
                context.SaveChanges();
            }
            return RedirectToAction("List");

        }

        public ActionResult Branch(int menuButtonId)
        {
            var parentButton = context.MenuButtons.FirstOrDefault(x => x.Id == menuButtonId);
            var Buttons = GetChildButtons(parentButton);

            return View(Buttons);
        }

        public ActionResult Add(int id)
        {
           var button = context.MenuButtons.FirstOrDefault(x => x.Id == id);
            if (button == null)
                return HttpNotFound();

            var newButton = new MenuButtonPage()
            {
                MenuButton = new MenuButton() {ParentId = button.Id, Level = button.Level + 1},
                Pages = new SelectList(context.InformationSources, "Id","Title")
            };
            
            return View(newButton);
        }

        [HttpPost]
        public ActionResult Add(MenuButtonPage button)
        {
            if (ModelState.IsValid)
            {
                button.MenuButton.Id = 0;
                button.MenuButton.InformationSourceId = button.SelectedPage;
                context.MenuButtons.Add(button.MenuButton);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult NewBranch()
        {
            MenuButtonPage button = new MenuButtonPage()
            {
                MenuButton = new MenuButton(){IsRootButton = true, Level = 0, ParentId = null},
                Pages = new SelectList(context.InformationSources, "Id", "Title")
            };
            return View("Add",button);
        }

        public ActionResult Delete(int menuButtonId)
        {
            var button = context.MenuButtons.FirstOrDefault(x => x.Id == menuButtonId);
            if (button==null)
            {
                return HttpNotFound();
            }
            var childButtons = GetChildButtons(button);
            childButtons.Add(button);
            
            foreach (var btn in childButtons)
            {
                context.MenuButtons.Remove(btn);
            }

            context.SaveChanges();


            return RedirectToAction("List");
        }

        private List<MenuButton> GetChildButtons(MenuButton parentButton)
        {
            List<MenuButton> Buttons = new List<MenuButton>();
            Stack<MenuButton> BranchButtons = new Stack<MenuButton>();
            var rootButton = parentButton;
            BranchButtons.Push(rootButton);

            while (BranchButtons.Count > 0)
            {
                var button = BranchButtons.Pop();
                Buttons.Add(button);
                var childrenNodes =
                    context.MenuButtons.Where(x => x.ParentId == button.Id).OrderByDescending(x => x.Name);
                if (childrenNodes.Any())
                {
                    foreach (var node in childrenNodes)
                    {

                        BranchButtons.Push(node);

                    }
                }
            }
            return Buttons;
        }

        private void PopulatePages(object selectedSource = null)
        {
            var informationSources = context.InformationSources.OrderBy(x=>x.Title).ToList();
           informationSources.Insert(0,new InformationSource(){Id = 0,Title = "Brak"});

            ViewBag.Pages = new SelectList(informationSources, "Id", "Title", selectedSource ?? 0);
        }

    }

}
