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

         //Seed dla u�ytkownik�w w pliku App_start/CreateRoles.cs
            //to musi zosta� dla zachowania sp�jno�ci

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
                        "Maturzy�ci, pochodz�cy z rodzi by�ych pracownik�w pa�stwowych przedsi�biorstw gospodarki rolnej, kt�rzy maj� zamiar  kontynuowa� nauk� na studiach dziennych, maj� szans� na stupendium. Szczeg�y na stronie: www.stypendia-pomostowe.pl.",
                    Date = DateTime.Now,
                    Title = "Z�odziejstwo"
                },
                new Models.News()
                {
                    AuthorId = 1,
                    Content = "Uczniowie! Przed nami egzaminy maturalne, z tego powodu w dniach 4-6 maja (poniedzia�ek, wtorek, �roda) odwo�ane s� zaj�cia lekcyjne. Uczniowie gimnazjum, kt�rzy chc� skorzysta� z zaj�� opieku�czych w tych dniach, proszeni s� o zg�oszenie tej informacji do sekretariatu szko�y w czwartek (30 kwietnia). Trzymamy kciuki za maturzyst�w! �yczymy Wam powodzenia!",
                    Date = DateTime.Now,
                    Title = "Matury 2015 ",
                    
                },
                new Models.News()
                {
                    AuthorId = 1,
                    Content = "zypominamy, �e najbli�sze spotkanie z Rodzicami odb�dzie si� we wtorek 24 marca 2015r. Rodzice maturzyst�w otrzymaj� informacj� o ocenach proponowanych na koniec klasy trzeciej.Zainteresowanych Rodzic�w zapraszamy w godzinach od 17.00 do 18.30",
                    Date = DateTime.Now,
                    Title = "Wywiad�wka"
                },
                new Models.News()
                {
                    AuthorId = 1,
                    Content = "Sobota 21.03.2015 roku w ZSO Nr I po�wi�cona by�a uczniom przygotowuj�cym si� do wa�nych egzamin�w. M�odzie� pracowa�a z arkuszami gimnazjalnymi i maturalnymi z matematyki. W trakcie trwania maratonu matematycznego uczniowie przyst�powali do pr�bnego egzaminu ustnego z j�zyka polskiego i j�zyka obcego.Taka forma zaj�� sta�a si� ju� od kilkunastu lat tradycj� naszej szko�y. Maturzy�ci pod okiem nauczycieli w mi�ej atmosferze na miesi�c przed egzaminami szlifuj� wiedz�. W tym roku podobnie jak w poprzednich latach go�cili�my uczni�w innych szk� �rednich miasta Opola.",
                    Date = DateTime.Now,
                    Title = "Ale �eby w sobote do szko�y?"
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
                new Address() { City= "Opole", HouseNumber = 3,PostCode = "45-714", Street = "Licealna", Name = "Adres domy�lny"}
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
                    Name = "robi�",
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
