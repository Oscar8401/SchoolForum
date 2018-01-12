using System.ComponentModel.DataAnnotations;

namespace SchoolForum.Models
{
    public class Categories
    {
        public int Id{ get; set; }

      
        [Display(Name = "Name , Please enter your name")]
        [Required(ErrorMessage = "Name must not be more than 50 characters")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter description")]
        [StringLength(500)]
        public string Description { get; set; }


        public string Members{ get; set; }
    }
}