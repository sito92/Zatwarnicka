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
        public int Level { get; set; }
        public int? ParentId { get; set; }
        public int? InformationSourceId { get; set; }
        public int? PageId { get; set; }
        public virtual InforamtionSource InforamtionSource { get; set; }
        public virtual MenuButton Parent {get; set;}
        public virtual Page Page { get; set; }
    }
}