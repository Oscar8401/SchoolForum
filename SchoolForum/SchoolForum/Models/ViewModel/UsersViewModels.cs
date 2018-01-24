using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolForum.Models.ViewModel
{
    public class UsersViewModels
    {
        public string Id { get; set; }

        public string FirsName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Name { get { return FirsName + " " + LastName; } }

        public int Age { get; set; }

        public string Role { get; set; }

        public string Category { get; set; }

        public int NumbeOfMessages { get; set; }

        public string NumberOfReplies { get; set; }

        public UsersViewModels(){}

        public UsersViewModels(ApplicationUser a, CategoriesViewModel c, MessagesViewModel m, RepliesViewModels r )
        {
            Id = a.Id;
            FirsName = a.FirstName;
            LastName = a.LastName;
            Email = a.Email;
            Age = a.Age;
            Role = a.Role;
            Category = c.Name;
            NumbeOfMessages = m.NumberOfMessages;
            NumberOfReplies = r.Name;
        }
    }
}