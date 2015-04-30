using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace SchoolCMS
{
    public static class CreateRoles
    {
        public static void CreateRolesSeed()
        {
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }

            if (!Roles.RoleExists("CopyWriter"))
            {
                Roles.CreateRole("CopyWriter");
            }
           
        }
    }
}