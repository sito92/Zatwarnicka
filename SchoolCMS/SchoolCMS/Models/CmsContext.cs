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
        public DbSet<InformationSource> InformationSources { get; set; } 
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CmsSettings> CmsSettings { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<FileExtension> FileExtensions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LogoSettings> LogoSettings { get; set; }
 

        ////DBSety dla E-dziennika
        //public DbSet<Class> Classes { get; set; }
        //public DbSet<Grade> Grades { get; set; }
        //public DbSet<GradeValues> GradeValues { get; set; }
        //public DbSet<Lesson> Lessons { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<CommentBase> Comments { get; set; }
        //public DbSet<Subject> Subjects { get; set; }

        //public DbSet<Teacher> Teachers { get; set; }

        //public DbSet<Student> Students { get; set; }

    }
}