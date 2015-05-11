using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class GradeComment : CommentBase
    {
        public virtual Grade Grade { get; set; }

        public int GradeId { get; set; }
    }
}