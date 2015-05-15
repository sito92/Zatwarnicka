using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime;

namespace SchoolCMS.Models.EDiary
{
    public class Student :User
    {
        public virtual Class Class { get; set; }
        
        public int ClassId { get; set; }

        public ICollection<Grade> Grades { get; set; }
        public ICollection<StudentComment> StudentComments { get; set; } 
    }
}