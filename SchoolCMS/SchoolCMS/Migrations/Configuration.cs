using System.Collections.Generic;
using SchoolCMS.Models;
using WebGrease.Css.Extensions;

namespace SchoolCMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolCMS.Models.CmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolCMS.Models.CmsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            List<User> users = new List<User>()
            {
                new Admin()
                {
                    Email = "admin@cms.pl",
                    Name = "Jan",
                    Surname = "Nowak",
                    Username = "admin",
                }
            };
            users.ForEach(x => context.Users.AddOrUpdate(x));
             context.SaveChanges();
            List<Layout> layouts = new List<Layout>()
            {
                new Layout() {Name = "Default", Path = "/Content/Site.css"}
            };

            layouts.ForEach(x => context.Layouts.AddOrUpdate(x));
            context.SaveChanges();


            List<Models.CmsSettings> settingses = new List<Models.CmsSettings>()
            {
                new Models.CmsSettings() {LayoutId = 1, SchoolName = "Przyk³adowa szko³a"}
            };

            settingses.ForEach(x => context.CmsSettings.AddOrUpdate(x));
            context.SaveChanges();

            List<InformationSource> inforamtionSources = new List<InformationSource>()
            {
                new Page()
                {
                    AuthorId = 1,
                    Content =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sem turpis, dignissim ac lorem non, pellentesque placerat urna. Vestibulum in massa vitae odio sodales lacinia. Suspendisse nec gravida nisl. Vivamus id malesuada tellus. In hac habitasse platea dictumst. In tortor eros, gravida non tempus id, feugiat non odio. Phasellus non consectetur elit, in blandit nisi. Nam hendrerit purus vitae mi sollicitudin ultrices. Praesent volutpat nec nunc et fringilla.",
                    Date = DateTime.Now,
                    Title = "Lorem ipsum"
                },
                new Models.News()
                {
                    AuthorId = 1,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sem turpis, dignissim ac lorem non, pellentesque placerat urna. Vestibulum in massa vitae odio sodales lacinia. Suspendisse nec gravida nisl. Vivamus id malesuada tellus. In hac habitasse platea dictumst. In tortor eros, gravida non tempus id, feugiat non odio. Phasellus non consectetur elit, in blandit nisi. Nam hendrerit purus vitae mi sollicitudin ultrices. Praesent volutpat nec nunc et fringilla.",
                    Date = DateTime.Now,
                    Title = "Lorem ipsum",
                    
                }
            };
            inforamtionSources.ForEach(x => context.InformationSources.AddOrUpdate(x));
             context.SaveChanges();

            List<FileType> fileTypes = new List<FileType>()
            {
                new FileType() {Name = "Obraz"},
                new FileType() {Name = "Plik wykonywalny"},
                new FileType() {Name = "Plik tekstowy"},

            };
            fileTypes.ForEach(x=>context.FileTypes.AddOrUpdate(x));
            context.SaveChanges();

            List<File> files = new List<File>()
            {
                new File()
                {
                  
                    UploadDateTime = DateTime.Now,
                    Extension = ".jpeg",
                    FileName = "obraz",
                    FileTypeId = 1,
                    Name = "Fajny obrazek",
                    Size = 512
                },
                new File()
                {
                    UploadDateTime = DateTime.Now,
                    Extension = ".exe",
                    FileName = "plik",
                    FileTypeId = 1,
                    Name = "Plik2",
                    Size = 512
                },
                 new File()
                {
                    UploadDateTime = DateTime.Now,
                    Extension = ".exe",
                    FileName = "plik",
                    FileTypeId = 1,
                    Name = "Plik3",
                    Size = 512
                },
                                 new File()
                {
                    UploadDateTime = DateTime.Now,
                    Extension = ".exe",
                    FileName = "plik",
                    FileTypeId = 1,
                    Name = "Plik4",
                    Size = 512
                }
            };

            files.ForEach(x => context.Files.AddOrUpdate(x));
            context.SaveChanges();

            
            List<Tag> tags = new List<Tag>()
            {
                new Tag()
                {
                    Name = "Testowy"
                },
                new Tag()
                {
                    Name = "Testowy2"
                }
            };

            tags.ForEach(x => context.Tags.AddOrUpdate(x));
            context.SaveChanges();


            List<Models.FileExtension> fileExtensions = new List<Models.FileExtension>()
            {
                new Models.FileExtension() {Extension = ".exe", FileTypeId = 2},
                new Models.FileExtension() {Extension = ".jpeg", FileTypeId = 1},
                new Models.FileExtension() {Extension = ".jpg", FileTypeId = 1},
                new Models.FileExtension() {Extension = ".txt", FileTypeId = 3},

            };
            fileExtensions.ForEach(x=>context.FileExtensions.AddOrUpdate(x));
            context.SaveChanges();
        }
    }
}


