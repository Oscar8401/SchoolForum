using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolForum.Models.ViewModel
{
    public class Students
    {
        //public ICollection<Categories> category;

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Column(TypeName="datetime2")]
         
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }

        public string Role { get; set; }

        //public string category { get; set; }
        public ICollection<string> StudentRole { get; internal set; }
        //public ICollection<Categories> AttendedCategory { get; set; }

        //public ICollection<string> Student { get; set; }
        //public ICollection<string> StudentRole { get; internal set; }

        public Students() {}
        public Students(ApplicationUser x)
        {
            Id = x.Id;
            FirstName = x.FirstName;
            LastName = x.LastName;
            Email = x.Email;
            DateOfBirth = x.DateOfBirth;
            //category = x.category;
             
            
            


        }
    }
}