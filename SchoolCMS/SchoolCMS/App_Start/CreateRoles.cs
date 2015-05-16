using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using SchoolCMS.Models;
using WebMatrix.WebData;

namespace SchoolCMS
{
    public static class CreateRoles
    {
        private static string AdminLogin = WebConfigurationManager.AppSettings["AdminLogin"];
        private static string AdminPassword = WebConfigurationManager.AppSettings["AdminPassword"];
        public static void CreateRolesSeed()
        {
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");

                if (!WebSecurity.UserExists("admin"))
                {
                    WebSecurity.CreateUserAndAccount(AdminLogin, AdminPassword, new
                    {
                        Email = "admin@cms.pl",
                        Name = "Jan",
                        Surname = "Nowak",
                        Username = "admin",
                        Discriminator="Admin"
                    });
                    Roles.AddUserToRole(AdminLogin, "Administrator");
                }
            }

            if (!Roles.RoleExists("CopyWriter"))
            {
                Roles.CreateRole("CopyWriter");
            }


            List<User> users = new List<User>()
            {
                new CopyWriter()
                {
                    Email = "a.kowalski@cms.pl",
                    Name = "Adam",
                    Surname = "Kowalski",
                    Username = "akowalski",
                },
                new CopyWriter()
                {
                    Email = "m.szklanka@cms.pl",
                    Name = "Miłosz",
                    Surname = "Szklanka",
                    Username = "mszklanka",
                }
            };
            users.ForEach(x =>
            {
                if (!WebSecurity.UserExists(x.Username))
                {
                    WebSecurity.CreateUserAndAccount(x.Username, "qwerty123",
                        new
                        {
                            Email = x.Email,
                            Name = x.Name,
                            Surname = x.Surname,
                            Username = x.Username,
                            Discriminator = "CopyWriter"
                        });
                    Roles.AddUserToRole(x.Username, "CopyWriter");
                }

            });

            if (!Roles.RoleExists("Student"))
            {
                Roles.CreateRole("Student");
            }

            if (!Roles.RoleExists("Teacher"))
            {
                Roles.CreateRole("Teacher");
            }
        }
    }
}