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
                MenuButtons = GetButtons()

            };

            ViewBag.Settings = model;
        }

        protected CmsSettings GetSettings()
        {
            var settings = context.CmsSettings.FirstOrDefault();

            return settings;
        }

        private List<List<MenuButton>> GetButtons()
        {
            var rootButtons = GetRootButtons();

            return rootButtons.Select(GetChildButtons).ToList();
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
