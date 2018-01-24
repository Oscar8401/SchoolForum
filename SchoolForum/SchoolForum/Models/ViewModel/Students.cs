using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolForum.Models.ViewModel
{
    public class Students
    {
 
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public int Age { get; set; }

        public string Role { get; set; }

        public string Category { get; set; }

        public ICollection<string> StudentRole { get; internal set; }
 
        public Students() {}
        public Students(ApplicationUser x)
        {
            Id = x.Id;
            FirstName = x.FirstName;
            LastName = x.LastName;
            Email = x.Email;
            Age = x.Age;
            Role = x.Role;
            //Category = c.Name;
        }
    }
}