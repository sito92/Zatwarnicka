using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class CmsSettings
    {
        public int Id { get; set; }
        public int LayoutId{ get; set; }
        public string SchoolName { get; set; }
        public virtual Layout Layout{ get; set; }

        public virtual Address Address {get; set;}
        public int AdressId { get; set; }

        public int NewsAmountPerSite {get; set;}
        public virtual LogoSettings LogoSettings {get; set;}
        public int? LogoSetingsId { get; set; }
    }
}