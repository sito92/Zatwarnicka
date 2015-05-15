using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class Class
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Student> Students { get; set; } 

    }
}