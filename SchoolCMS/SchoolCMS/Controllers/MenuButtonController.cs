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
        public ActionResult Details(int menuButtonId)
        {
            var menuButton = context.MenuButtons.FirstOrDefault(x => x.Id == menuButtonId);

            if (menuButton==null)
            {
                return HttpNotFound();
            }

            return View(menuButton);
        }

        public ActionResult Branch(int menuButtonId)
        {
            List<MenuButton> Buttons = new List<MenuButton>();
            Stack<MenuButton> BranchButtons = new Stack<MenuButton>();
            var rootButton = context.MenuButtons.FirstOrDefault(x => x.Id == menuButtonId);
            BranchButtons.Push(rootButton);

            while (BranchButtons.Count > 0)
            {
                var button = BranchButtons.Pop();
                Buttons.Add(button);
                var childrenNodes = context.MenuButtons.Where(x => x.ParentId == button.Id);
                if (childrenNodes.Any())
                {
                    foreach (var node in childrenNodes)
                    {
                        
                        BranchButtons.Push(node);

                    }
                }
            }
           

            return View(Buttons);
        }

        public ActionResult Add(int id)
        {
           var button = context.MenuButtons.FirstOrDefault(x => x.Id == id);

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
    }
}
