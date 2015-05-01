using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models;

namespace SchoolCMS.ViewModels
{
    public class CmsViewModel
    {
        public CmsSettings CmsSettings { get; set; }
        public List<List<MenuButton>> MenuButtons { get; set; } 
    }
}