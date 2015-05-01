using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;
using SchoolCMS.ViewModels;

namespace SchoolCMS.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected CmsContext context = new CmsContext();
        public BaseController()
        {
            var settings = GetSettings();
            var rootButtons = GetRootButtons();

            CmsViewModel model = new CmsViewModel()
            {
                CmsSettings = GetSettings(),
                MenuButtons = GetChildButtons(rootButtons[1])

            };

            ViewBag.Settings = model;
        }

        protected CmsSettings GetSettings()
        {
            var settings = context.CmsSettings.FirstOrDefault();

            return settings;
        }

        private List<Button> GetButtons()
        {
            List<Button> result = new List<Button>();
            var rootButtons = GetRootButtons();
            return result;
        }
        private List<MenuButton> GetRootButtons()
        {
            return context.MenuButtons.Where(x => x.IsRootButton).ToList();
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
    }
}
