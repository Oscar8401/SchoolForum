namespace SchoolForum.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
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
                    DateOfBirth = DateTime.Now
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
                    DateOfBirth = DateTime.Now
                };
                var result = userManager.Create(user, "password");
            }
            context.Categories.AddOrUpdate(x => x.Name,
                new Categories { Name = "Leadership", Description = "Body language for leader.", Members = "Johnathon" },
                new Categories { Name = "Communication", Description = "Communication with Confidence.", Members = "Taleb" },
                new Categories { Name = "Collaboration", Description = "Finding your Introvert/Extrovert balance in the Workplace", Members = "Mathew" },
                new Categories { Name = "English", Description = "An entry level to ITprofessional English", Members = "Kim" },
                new Categories { Name = "DotNet", Description = "Asp.Net MVC", Members = "Samantha" },
                new Categories { Name = "Swedish", Description = "Entry level to the swedish language.", Members = "Samantha" },
                new Categories { Name = "FrontEnd", Description = "HTML-CSS3-JavaScript", Members = "Samantha" },
                new Categories { Name = "DeepLearning", Description = "Learning How to Learn:Powerful mental tools to help you master tough subjects.", Members = "Tom" },
                new Categories { Name = "TimeManagement", Description = "Creating Great Workplace Habits.", Members = "Rahul" },
                new Categories { Name = "Bitcoin", Description = "To really understand what is special about Bitcoin", Members = "Sunisa" }
                );

            context.MessageViewModels.AddOrUpdate(x => x.Title,
                new Models.ViewModel.MessageViewModel { Title = "Need help", Text = "Hello can some one help me!", PostingDate = DateTime.Now, Textreply="Can you be more clear with what do you want." },
                new Models.ViewModel.MessageViewModel { Title = "StartingDate", Text = "When the english course will start", PostingDate = DateTime.Now, Textreply="It will start next week." },
                new Models.ViewModel.MessageViewModel { Title = "Leadership", Text = "I want to ask how long will be the cource.", PostingDate = DateTime.Now, Textreply="The cource will be 2 weeks, 3 days per week" },
                new Models.ViewModel.MessageViewModel { Title = "DotNet", Text = "I want to ask what is the requirment for the cource, because I don't have any previous expiriance.", PostingDate = DateTime.Now, Textreply="You should pass the test modul." },
                new Models.ViewModel.MessageViewModel { Title = "Swedish", Text = "When the cource will start, and what we need to have with us.", PostingDate = DateTime.Now, Textreply="next week, you don't neet to have anything with you" },
                new Models.ViewModel.MessageViewModel { Title = "FrontEnd", Text = "Are we going to study javaScript framework also? for exampel angular! and if yes which are they?", PostingDate = DateTime.Now,Textreply="yes, we are going to work with anjularJs." },
                new Models.ViewModel.MessageViewModel { Title = "TimeManagement", Text = "How many days will be the cource.", PostingDate = DateTime.Now, Textreply="the course will be 3 days." },
                new Models.ViewModel.MessageViewModel { Title = "Bitcoin", Text = "This cource sounds really intressting, but can you provide us more information about!.", PostingDate = DateTime.Now, Textreply="yes you are going to have digital book, pdf"},
                new Models.ViewModel.MessageViewModel { Title = "Passwordhelp", Text = "I need help looks like someone had hack my account!.", PostingDate = DateTime.Now, Textreply="You should contact the admin." },
                new Models.ViewModel.MessageViewModel { Title = "mail", Text = "Where I can see my message", PostingDate = DateTime.Now, Textreply="In your mail box :)" }

                );
        }
    }
}
