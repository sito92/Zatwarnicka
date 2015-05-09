using System.Collections.Generic;
using SchoolCMS.Models;
using WebMatrix.WebData;

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
                    Email = "cos@cms.pl",
                    Name = "cos",
                    Surname = "cos",
                    Username = "cos",
                }
            };
            users.ForEach(x => context.Users.AddOrUpdate(x));
            context.SaveChanges();

         //Seed dla u¿ytkowników w pliku App_start/CreateRoles.cs
            //to musi zostaæ dla zachowania spójnoœci

            List<Layout> layouts = new List<Layout>()
            {
                new Layout() {Name = "Default", Path = "/Content/Site.css"}
            };

            layouts.ForEach(x => context.Layouts.AddOrUpdate(x));
            context.SaveChanges();



            List<InformationSource> inforamtionSources = new List<InformationSource>()
            {
                new News()
                {
                    AuthorId = 1,
                    Content =
                        "Maturzyœci, pochodz¹cy z rodzi by³ych pracowników pañstwowych przedsiêbiorstw gospodarki rolnej, którzy maj¹ zamiar  kontynuowaæ naukê na studiach dziennych, maj¹ szansê na stupendium. Szczegó³y na stronie: www.stypendia-pomostowe.pl.",
                    Date = DateTime.Now,
                    Title = "Z³odziejstwo"
                },
                new Models.News()
                {
                    AuthorId = 1,
                    Content = "Uczniowie! Przed nami egzaminy maturalne, z tego powodu w dniach 4-6 maja (poniedzia³ek, wtorek, œroda) odwo³ane s¹ zajêcia lekcyjne. Uczniowie gimnazjum, którzy chc¹ skorzystaæ z zajêæ opiekuñczych w tych dniach, proszeni s¹ o zg³oszenie tej informacji do sekretariatu szko³y w czwartek (30 kwietnia). Trzymamy kciuki za maturzystów! ¯yczymy Wam powodzenia!",
                    Date = DateTime.Now,
                    Title = "Matury 2015 ",
                    
                },
                new Models.News()
                {
                    AuthorId = 1,
                    Content = "zypominamy, ¿e najbli¿sze spotkanie z Rodzicami odbêdzie siê we wtorek 24 marca 2015r. Rodzice maturzystów otrzymaj¹ informacjê o ocenach proponowanych na koniec klasy trzeciej.Zainteresowanych Rodziców zapraszamy w godzinach od 17.00 do 18.30",
                    Date = DateTime.Now,
                    Title = "Wywiadówka"
                },
                new Models.News()
                {
                    AuthorId = 1,
                    Content = "Sobota 21.03.2015 roku w ZSO Nr I poœwiêcona by³a uczniom przygotowuj¹cym siê do wa¿nych egzaminów. M³odzie¿ pracowa³a z arkuszami gimnazjalnymi i maturalnymi z matematyki. W trakcie trwania maratonu matematycznego uczniowie przystêpowali do próbnego egzaminu ustnego z jêzyka polskiego i jêzyka obcego.Taka forma zajêæ sta³a siê ju¿ od kilkunastu lat tradycj¹ naszej szko³y. Maturzyœci pod okiem nauczycieli w mi³ej atmosferze na miesi¹c przed egzaminami szlifuj¹ wiedzê. W tym roku podobnie jak w poprzednich latach goœciliœmy uczniów innych szkó³ œrednich miasta Opola.",
                    Date = DateTime.Now,
                    Title = "Ale ¿eby w sobote do szko³y?"
                },
                new Models.Page()
                {
                    AuthorId = 1,
                    Content = "a \r\n b\r c\n d"+Environment.NewLine,
                    Date = DateTime.Now,
                    Title = "Kontakt"
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
            fileTypes.ForEach(x => context.FileTypes.AddOrUpdate(x));
            context.SaveChanges();

            List<File> files = new List<File>()
            {
                new File()
                {
                  
                    UploadDateTime = DateTime.Now,
                    Extension = ".jpeg",
                    FileName = "obraz",
                    FileTypeId = 1,
                    Name = "Plik_graficzny",
                    Size = 512
                },
                new File()
                {
                    UploadDateTime = DateTime.Now,
                    Extension = ".exe",
                    FileName = "plik",
                    FileTypeId = 1,
                    Name = "Plik_wykonywalny",
                    Size = 512
                },
                new File()
                {
                    UploadDateTime = DateTime.Now,
                    Extension = ".exe",
                    FileName = "plik",
                    FileTypeId = 1,
                    Name = "Plik_wykonywalny2",
                    Size = 512
                },
                new File()
                {
                    UploadDateTime = DateTime.Now,
                    Extension = ".exe",
                    FileName = "plik",
                    FileTypeId = 1,
                    Name = "Plik_wykonywalny3",
                    Size = 512
                }
            };

            files.ForEach(x => context.Files.AddOrUpdate(x));
            context.SaveChanges();


            List<Tag> tags = new List<Tag>()
            {
                new Tag()
                {
                    Name = "Organizacyjne"
                },
                new Tag()
                {
                    Name = "Inne"
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
            fileExtensions.ForEach(x => context.FileExtensions.AddOrUpdate(x));
            context.SaveChanges();

            List<Address> addresses = new List<Address>()
            {
                new Address() { City= "Opole", HouseNumber = 3,PostCode = "45-714", Street = "Licealna", Name = "Adres domyœlny"}
            };
            addresses.ForEach(x => context.Addresses.AddOrUpdate(x));
            context.SaveChanges();

            List<LogoSettings> logoSettings = new List<LogoSettings>()
            {
                new LogoSettings(){LogoName = "a", LogoPath = "a"}
            };
            logoSettings.ForEach(x => context.LogoSettings.AddOrUpdate(x));
            context.SaveChanges();

            List<MenuButton> menuButtons = new List<MenuButton>()
            {
                new MenuButton()
                {
                    Name = "Kontakt",
                    IsRootButton = true,
                    Level = 0,
                    InformationSourceId = 5
                },
                new MenuButton()
                {
                    Name = "Nie mam",
                    IsRootButton = true,
                    Level = 0,
                },                
                new MenuButton()
                {
                    Name = "pojecia co",
                    IsRootButton = false,
                    Level = 1,
                    ParentId = 2,
                },
                new MenuButton()
                {
                    Name = "robiê",
                    IsRootButton = false,
                    Level = 2,
                    ParentId = 3,
                    InformationSourceId = 1
                },
            };
            menuButtons.ForEach(x => context.MenuButtons.AddOrUpdate(x));
            context.SaveChanges();


            List<Models.CmsSettings> settingses = new List<Models.CmsSettings>()
            {
                new Models.CmsSettings() {LayoutId = 1, SchoolName = "I LO w Opolu", NewsAmountPerSite=2,AdressId=1}
            };

            settingses.ForEach(x => context.CmsSettings.AddOrUpdate(x));
            context.SaveChanges();
        }
    }
}
