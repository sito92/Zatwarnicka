using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolCMS.Models
{
    public class CmsContext:DbContext
    {
        public CmsContext() : base("LocalConnection")
        {
            
        }


        DbSet<MenuButton> MenuButtons { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<Layout> Layouts { get; set; }
        DbSet<News> Newses { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<Tag> Tags { get; set; }
 
    }
}