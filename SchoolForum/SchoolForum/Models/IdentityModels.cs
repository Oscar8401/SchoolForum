using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Please enter your first name.")]
        [DisplayName("First Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        [StringLength(100)]
        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [DisplayName("First Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]        
        [StringLength(100)]
        
        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        //public virtual ICollection<Message> Messages { get; set; }
        //public virtual ICollection<Reply> Replys { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //add the connection tho the categories table
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SchoolForum.Models.Categories> Categories { get; set; }

        //public System.Data.Entity.DbSet<SchoolForum.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}