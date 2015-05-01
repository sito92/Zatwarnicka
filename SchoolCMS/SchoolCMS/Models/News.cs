using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class News : InformationSource
    {
        public virtual ICollection<Tag> Tags { get; set; }
        [NotMapped]
        public string ShortContent {
            get
            {
                return Content.Length < 150 ? Content : Content.Substring(0, 150);
            } }
    }
}