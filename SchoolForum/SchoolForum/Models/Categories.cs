using SchoolForum.Utility;
using System.ComponentModel.DataAnnotations;

namespace SchoolForum.Models
{
    public class Categories
    {
        public int Id{ get; set; }

      
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please enter category name")] 
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special characters not allowed")]
        [StringLength(50)]
        [MaxWords(2)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter description")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special characters not allowed")]
        [StringLength(500)]
        public string Description { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special characters not allowed")]
        public string Members{ get; set; }
    }
}