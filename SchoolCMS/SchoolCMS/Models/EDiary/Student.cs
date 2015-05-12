using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class Student : User
    {
        public virtual ICollection<StudentComment> StudentComments  { get; set; }

        public virtual Class Class { get; set; }

        public int ClassId { get; set; }

        public virtual ICollection<Grade> Grade {get; set;}


    }
}