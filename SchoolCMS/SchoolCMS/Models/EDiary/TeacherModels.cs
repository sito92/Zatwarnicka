using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models.EDiary
{
    public class TeacherModels
    {
        public class ChangeTeacherPassword : ChangePasswordModel
        {
        }

        public class ChangeTeacherData : ChangePersonalDataModel
        {
        }

        public class TeacherRegisterModel : RegisterModel
        {
        }
    }
}