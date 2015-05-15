using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolCMS.Models;
using SchoolCMS.Models.EDiary;

namespace SchoolCMS.Helpers
{
    public static class ClassStudentsHelper
    {
        public static void ManageStudents(this Class myClass, IEnumerable<int> studentsToRemove,
            IEnumerable<int> studentsToAdd,CmsContext context)
        {
            RemoveStudents(myClass,studentsToRemove,context);
            AddStudents(myClass,studentsToAdd,context);
        }

        private static void RemoveStudents(Class myClass, IEnumerable<int> studentsToRemove, CmsContext context)
        {
            if (studentsToRemove==null || !studentsToRemove.Any())
            {
                return;
            }
            var contextStudentsToRemove = context.Users.OfType<Student>().Where(x => studentsToRemove.Contains(x.Id));
            foreach (var studentToRemove in contextStudentsToRemove)
            {
                if (myClass.Students.Contains(studentToRemove))
                {

                    myClass.Students.Remove(studentToRemove);
                }
            }

        }

        private static void AddStudents(Class myClass, IEnumerable<int> studentsToAdd, CmsContext context)
        {
            if (studentsToAdd == null || !studentsToAdd.Any())
            {
                return;
            }
            var contextStudentsToAdd = context.Users.OfType<Student>().Where(x => studentsToAdd.Contains(x.Id));

            if (!contextStudentsToAdd.Any())
            {
                return;
            }

            foreach (var studentToAdd in contextStudentsToAdd)
            {
                if (!myClass.Students.Contains(studentToAdd))
                {
                    myClass.Students.Add(studentToAdd);
                }
            }
        }
    }
}