using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.Controllers
{
    public class MenuButtonController : Controller
    {
        CmsContext context = new CmsContext();
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
            PopulatePages(menuButton.PageId);
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
            if (button.PageId==0)
            {
                button.PageId = null;
            }
            dbButton.Name = button.Name;
            dbButton.PageId = button.PageId;
            context.SaveChanges();
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
            var newButton = new MenuButton() {ParentId = button.Id, Level = button.Level+1};
            return View(newButton);

        }

        [HttpPost]
        public ActionResult Add(MenuButton button)
        {
            button.Id = 0;
            context.MenuButtons.Add(button);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult NewBranch()
        {
            MenuButton button = new MenuButton() {IsRootButton = true, Level = 0, ParentId = null};
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

        private void PopulatePages(object selectedPage = null)
        {
            var pages = context.Pages.OrderBy(x=>x.Title).ToList();
           pages.Insert(0,new Page(){Id = 0,Title = "Brak"});

            ViewBag.Pages = new SelectList(pages, "Id", "Title", selectedPage ?? 0);
        }

    }

}
