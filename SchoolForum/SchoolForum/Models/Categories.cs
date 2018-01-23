using SchoolForum.Utility;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolForum.Models
{
    public class Categories
    {
        public int Id{ get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]
        [MaxWords(2, ErrorMessage = "Name can not be more than 2 words.")]
        [DisplayName("Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]
        [MaxWords(100, ErrorMessage = "Description can not be more than 2 words.")]
        [DisplayName("Description")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string Description { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special characters not allowed")]
        public string Members{ get; set; }
    }
}