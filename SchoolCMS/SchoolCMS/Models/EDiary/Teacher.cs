using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class Teacher:User
    {
        public int Id { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; } 
    }
}