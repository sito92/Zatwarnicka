using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class News : InforamtionSource
    {
        public virtual ICollection<Tag> Tags { get; set; }
    }
}