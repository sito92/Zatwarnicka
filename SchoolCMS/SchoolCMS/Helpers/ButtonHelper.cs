using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.Helpers
{
    public static class ButtonHelper
    {
        private const string openLi = "<li>";
        private const string closeLi = "</li>";
        private const string openUl = "<ul>";
        private const string closeUl = "</ul>";
        private const string informationSourceController = "/InformationSource";
        private const string informationSourceShowAction = "/Show/";
        private const string openButtonStyle = "<div id='buttonStyle'>";
        private const string closeDiv = "</div>";
        public static MvcHtmlString ButtonList(this HtmlHelper helper, List<List<MenuButton>> sortedMenuButtons, string listId)
        {
            string result = "";


            foreach (var branch in sortedMenuButtons)
            {

                foreach (var button in branch)
                {
                    result += openLi;
                    result = GetListElement(result, button);
                    var i = branch.IndexOf(button);
                    if (i + 1 <= branch.Count - 1)
                    {
                        result = GetTags(branch, i, button, result);
                    }
                    else
                    {
                         var l = branch.Select(x => x.Level).Max();
                        result += GetClosingTags(l);
                    }
                }
            }
            return new MvcHtmlString(result.Replace("<li></li>",string.Empty));
        }

        private static string GetListElement(string result, MenuButton button)
        {
            if (button.InformationSourceId!=null)
            {
                result += GetButtonWithATag(button);
            }
            else
            result += GetButtonWithStyleDiv(button);

            return result;
        }

        private static string GetTags(List<MenuButton> branch, int i, MenuButton button, string result)
        {
            if (branch[i + 1].Level > button.Level)
            {
                result += openUl;
            }
            else if (branch[i + 1].Level == button.Level)
            {
                result += closeLi;
            }
            else if (branch[i + 1].Level < button.Level)
            {
                var l = button.Level - branch[i + 1].Level;
                result += GetClosingTags(l);
            }
            return result;
        }

        private static string GetClosingTags(int amount)
        {
            var closingTags = "";
            for (int i = 0; i < amount; i++)
            {
                closingTags += closeLi;
                closingTags += closeUl;
            }
            return closingTags;

        }

        private static string GetButtonWithATag(MenuButton button)
        {
            var result = "<a href='" + informationSourceController + informationSourceShowAction + button.InformationSourceId+ "'>";
            result += button.Name;
            result += "</a>";
            return result;
        }

        private static string GetButtonWithStyleDiv(MenuButton button)
        {
            var result = openButtonStyle;
            result += button.Name;
            result += closeDiv;
            return result;
        }
        

    }
}