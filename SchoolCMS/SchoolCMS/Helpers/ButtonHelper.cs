using System;
using System.Collections.Generic;
using System.Linq;
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
        public static MvcHtmlString ButtonList(this HtmlHelper helper, List<List<MenuButton>> sortedMenuButtons, string listId)
        {
            string result = "";


            foreach (var branch in sortedMenuButtons)
            {
                result += openLi;
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
            return new MvcHtmlString(result);
        }

        private static string GetListElement(string result, MenuButton button)
        {
            if (button.InformationSourceId!=null)
            {
                
            }
            result += button.Name;

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
        

    }
}