using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class MenuButton
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsRootButton { get; set; }
        public int  Level { get; set; }
        public int ParentId { get; set; }
        public virtual MenuButton Parent {get; set;}
    }
}