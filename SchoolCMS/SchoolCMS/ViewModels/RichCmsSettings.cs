using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolCMS.Models;

namespace SchoolCMS.ViewModels
{
    public class RichCmsSettings
    {
        public string SchoolName { get; set; }

        public int NewsAmountPerSite { get; set; }

        public int SelectedLayoutId { get; set; }

        public IEnumerable<SelectListItem> Layouts { get; set; }

        public int SelectedAddressId { get; set; }

        public IEnumerable<SelectListItem> Addresses { get; set; }

        public int SelectedLogoSettingsId { get; set; }

        public IEnumerable<SelectListItem> LogoSettings { get; set; } 
    }
}