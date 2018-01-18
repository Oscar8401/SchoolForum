using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
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

        //adding the new properties

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

        [Required(ErrorMessage ="Please enter the date of birth")]
        [Column(TypeName= "datetime2")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        //public string Role { get; set; }

        //public virtual ICollection<Message> Messages { get; set; }
        //public virtual ICollection<Reply> Replys { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //add the connection tho the categories table
        //public DbSety<Categories> Categoriess { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) 
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SchoolForum.Models.Categories> Categories { get; set; }
    }
}