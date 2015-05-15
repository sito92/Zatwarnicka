using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class Grade
    {
        public int Id { get; set; }

        public virtual GradeValues GradeValue { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public int GradeValueId { get; set; }
        public int? GradeCommentId { get; set; }
        public virtual GradeComment GradeComment { get; set; }


    }
}