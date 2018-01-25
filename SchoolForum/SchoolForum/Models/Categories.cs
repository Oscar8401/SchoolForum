using SchoolForum.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "datetime2")]
        public DateTime CreatingTime { get; set; }




        public string Members{ get; set; }
        public ICollection<Message> messages { get; set; }
        public ICollection<ApplicationUser> user { get; set; }

    }
}