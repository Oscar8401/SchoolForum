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
            if (!context.Roles.Any(x => x.Name == "Teacher"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "Teacher" });
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
                    DateOfBirth = DateTime.Now,
                    //Role = "Teacher"
                };
                var result = userManager.Create(user, "password");
                userManager.AddToRole(user.Id, "Teacher");
            }

            if (!context.Roles.Any(x => x.Name == "Student"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "Student" });
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
                    DateOfBirth = DateTime.Now,
                    //Role = "Student"
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

            //context.MessageViewModels.AddOrUpdate(x => x.Title,
            //    new Models.ViewModel.MessageViewModel { Title = "Need help", Text = "Hello can some one help me!", PostingDate = DateTime.Now, Textreply="Can you be more clear with what do you want." },
            //    new Models.ViewModel.MessageViewModel { Title = "StartingDate", Text = "When the english course will start", PostingDate = DateTime.Now, Textreply="It will start next week." },
            //    new Models.ViewModel.MessageViewModel { Title = "Leadership", Text = "I want to ask how long will be the cource.", PostingDate = DateTime.Now, Textreply="The cource will be 2 weeks, 3 days per week" },
            //    new Models.ViewModel.MessageViewModel { Title = "DotNet", Text = "I want to ask what is the requirment for the cource, because I don't have any previous expiriance.", PostingDate = DateTime.Now, Textreply="You should pass the test modul." },
            //    new Models.ViewModel.MessageViewModel { Title = "Swedish", Text = "When the cource will start, and what we need to have with us.", PostingDate = DateTime.Now, Textreply="next week, you don't neet to have anything with you" },
            //    new Models.ViewModel.MessageViewModel { Title = "FrontEnd", Text = "Are we going to study javaScript framework also? for exampel angular! and if yes which are they?", PostingDate = DateTime.Now,Textreply="yes, we are going to work with anjularJs." },
            //    new Models.ViewModel.MessageViewModel { Title = "TimeManagement", Text = "How many days will be the cource.", PostingDate = DateTime.Now, Textreply="the course will be 3 days." },
            //    new Models.ViewModel.MessageViewModel { Title = "Bitcoin", Text = "This cource sounds really intressting, but can you provide us more information about!.", PostingDate = DateTime.Now, Textreply="yes you are going to have digital book, pdf"},
            //    new Models.ViewModel.MessageViewModel { Title = "Passwordhelp", Text = "I need help looks like someone had hack my account!.", PostingDate = DateTime.Now, Textreply="You should contact the admin." },
            //    new Models.ViewModel.MessageViewModel { Title = "mail", Text = "Where I can see my message", PostingDate = DateTime.Now, Textreply="In your mail box :)" }

            //    );

            context.MessagesViewModels.AddOrUpdate(x => x.Title,
                new Models.ViewModel.MessagesViewModel { Title = "About the starting date", Text = "Hello can anyone tell me when it'll start?", CategoryName = "Leadership", PostingDate = DateTime.Now, User = "Jack", NumberOfMessages= 3},
                new Models.ViewModel.MessagesViewModel { Title = "Help", Text = "What this course will be about?", CategoryName = "Leadership", PostingDate = DateTime.Now, User = "Samantha" },
                new Models.ViewModel.MessagesViewModel { Title = "Explanation", Text = "Are you going to hold the course in English or Swedish?", CategoryName = "Communication", PostingDate = DateTime.Now.AddDays(-5), User = "Pia", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Information", Text = "How many days the course will hold?", CategoryName = "Communication", PostingDate = DateTime.Now.AddDays(-2), User = "Brad", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "More information", Text = "Can you tell me more information about this course?", CategoryName = "Collaboration", PostingDate = DateTime.Now.AddDays(-1), User = "Monica", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "About the class", Text = "Are you going to have the same course in English also in the future?", CategoryName = "Collaboration", PostingDate = DateTime.Now.AddDays(-10), User = "Jermy", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "class level", Text = "What is the level of this course?", CategoryName = "English", PostingDate = DateTime.Now.AddDays(-15), User = "Henrik", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "When", Text = "When the next level going start?", CategoryName = "English", PostingDate = DateTime.Now.AddDays(-20), User = "Louis", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Needhelp", Text = "I need help with installing the .net platform!", CategoryName = "DotNet", PostingDate = DateTime.Now.AddDays(-2), User = "Sofia", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Does any one know", Text = "Does anyone knows if we are going to work with MVC 5 or MVC4?", CategoryName = "DotNet", PostingDate = DateTime.Now.AddDays(-22), User = "Fredrik", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "When", Text = "Hello can anyone tell me when it'll start?", CategoryName = "Swedish", PostingDate = DateTime.Now.AddDays(-19), User = "Jenever", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Help", Text = "I don't know any Swedish at all! still can follow this course?", CategoryName = "Swedish", PostingDate = DateTime.Now.AddDays(-10), User = "Anna", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Class", Text = "How many we will be in this course?", CategoryName = "FrontEnd", PostingDate = DateTime.Now.AddDays(-8), User = "Barbara", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "More information", Text = "Are we going to study javaScript frame work during this course and which?", CategoryName = "FrontEnd", PostingDate = DateTime.Now.AddDays(-5), User = "Tommy", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Need more details", Text = "Does the course going to be in english or Swedish?", CategoryName = "DeepLearning", PostingDate = DateTime.Now.AddDays(-6), User = "Tom", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Explanation", Text = "Do we need to have our own computers with us?", CategoryName = "DeepLearning", PostingDate = DateTime.Now.AddDays(-7), User = "Gorge", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Details", Text = "Does it going to be in English or Swedish?", CategoryName = "TimeManagement", PostingDate = DateTime.Now.AddDays(-18), User = "Ebbi", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "About the class", Text = "Hello can anyone tell me when it'll start?", CategoryName = "TimeManagement", PostingDate = DateTime.Now.AddDays(-1), User = "Simon", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Information", Text = "Hello can anyone tell me when it'll start?", CategoryName = "Bitcoin", PostingDate = DateTime.Now.AddDays(-27), User = "Amanda", NumberOfMessages = 3 },
                new Models.ViewModel.MessagesViewModel { Title = "Need Help", Text = "Can you give us more information about this course? what we will be doing, which materials are we going to use!", CategoryName = "Bitcoin", PostingDate = DateTime.Now.AddDays(-55), User = "Daiana", NumberOfMessages = 3 }

                );
        }
    }
}
