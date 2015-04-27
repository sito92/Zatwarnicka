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


        public DbSet<MenuButton> MenuButtons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<InforamtionSource> InforamtionSources { get; set; } 
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CmsSettings> CmsSettings { get; set; }
        public DbSet<FileType> FileTypes { get; set; } 
    }
}