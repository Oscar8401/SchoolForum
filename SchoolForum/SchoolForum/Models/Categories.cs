using SchoolForum.Utility;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolForum.Models
{
    public class Categories
    {
        public int Id{ get; set; }

        [Required(ErrorMessage = "Requird")]
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


        public string Members{ get; set; }

        public virtual Message message { get; set; }
        public ICollection<Categories> AttendedCategory { get; set; }
        public ICollection<ApplicationUser> user { get; set; }

        //public ICollection<string> Student { get; set; }
        //public ICollection<string> StudentRole { get; internal set; }
    }
}