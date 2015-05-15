using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class CommentBase
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}