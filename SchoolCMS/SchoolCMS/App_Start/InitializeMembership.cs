using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace SchoolCMS
{
    public static class InitializeMembership
    {
        public static void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("LocalConnection", "Users", "Id", "Username", autoCreateTables:true);
        }
    }
}