using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class Teacher : User
    {
        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual TeacherSchedule TeacherSchedule { get; set; }

        public int TeacherScheduleId { get; set; }
    }
}