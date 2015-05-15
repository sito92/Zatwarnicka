using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models.EDiary;

namespace SchoolCMS.ViewModels.EDiary.ClassViewModels
{
    public class ClassViewModel
    {
        public ClassViewModel()
        {
            Class = new Class();
        }
        public Class Class { get; set; }
        public List<Lesson> AvaiableLessons { get; set; }
        public List<Student> AvaiableStudents { get; set; }
    }
}