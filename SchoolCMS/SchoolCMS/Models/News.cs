using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class News:InforamtionSource
    {
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}