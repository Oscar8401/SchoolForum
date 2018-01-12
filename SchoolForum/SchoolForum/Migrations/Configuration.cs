namespace SchoolForum.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolForum.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(x => x.Name == "teacher"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "teacher" });
            }

            if (!context.Users.Any(y => y.UserName == "teacher@school.se"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser
                {
                    UserName = "teacher@school.se",
                    Email = "teacher@school.se",
                    FirstName = "Teacher",
                    LastName = "teacher",
                    DateOfBirth = "1960-01-11"
                };
                var result = userManager.Create(user, "password");
                userManager.AddToRole(user.Id, "teacher");
            }
            if (!context.Users.Any(x => x.UserName == "student@school.se"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = "student@school.se",
                    Email = "student@school.se",
                    FirstName = "Student",
                    LastName = "student",
                    DateOfBirth = "2008-01-11"
                };
                var result = userManager.Create(user, "password");
            }
            context.Categories.AddOrUpdate(x => x.Name,
                new Categories { Name = "Football", Description = "We are looking to create a new football team.", Members = "Student1, Student2, Student3" },
                new Categories { Name = "Language", Description = "Do you want to learn a new language from native speaker.", Members = "Student4, Student5, Student6" },
                new Categories { Name = "Photographing", Description = "Do you have a passion for photographing! come and join us.", Members = "Student7, Student8, Student9" }
                );
        }
    }
}