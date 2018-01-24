using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolForum.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

 
        [Required(ErrorMessage = "Please enter the first name.")]
        [DisplayName("First Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name.")]
        [DisplayName("Last Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]        
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [Range(1, 65, ErrorMessage = "Age has to be between 1 and 65")]
        public int Age { get; set; }

        public string Role { get; set; }

        public int MembersCount { get; set; }

        public virtual ICollection<Message> messages { get; set; }
        public virtual ICollection<Categories> category { get; set; }
        public virtual ICollection<Reply> replies { get; set; }

     }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SchoolForum.Models.Categories> Categories { get; set; }

        public System.Data.Entity.DbSet<SchoolForum.Models.Message> Messages { get; set; }

        public System.Data.Entity.DbSet<SchoolForum.Models.Reply> Replies { get; set; }

        public System.Data.Entity.DbSet<SchoolForum.Models.ViewModel.MessagesViewModel> MessagesViewModels { get; set; }

        public System.Data.Entity.DbSet<SchoolForum.Models.ViewModel.CategoriesViewModel> CategoriesViewModels { get; set; }
    }
}