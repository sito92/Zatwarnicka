using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class ClassSchedule : Schedule
    {
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}