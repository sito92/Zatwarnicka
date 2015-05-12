using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class Lesson
    {
        public int Id { get; set; }

        public virtual Subject Subject { get; set; }

        public int SubjectId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public int TeacherId { get; set; }

        public virtual Class Class { get; set; }

        public int ClassId { get; set; }
    }
}