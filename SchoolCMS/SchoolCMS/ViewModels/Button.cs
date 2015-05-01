using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models;

namespace SchoolCMS.ViewModels
{
    public class Button
    {
        public Button ParrentButton { get; set; }
        public MenuButton MenuButton { get; set; }
        public bool IsRoot
        {
            get
            {
                return ParrentButton==null;
            }
        }
        public List<Button> ChildButtons { get; set; }

        public bool IsLeap
        {
            get {
                return ChildButtons==null || ChildButtons.Count >0;
            }
        }
    }
}