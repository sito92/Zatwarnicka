using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class StudentComment : CommentBase
    {
        public virtual Student Student { get; set; }

        public int StudentId { get; set; }
    }
}