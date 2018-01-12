using SchoolForum.Utility;
using System.ComponentModel.DataAnnotations;

namespace SchoolForum.Models
{
    public class Categories
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(50)]
        [MaxWords(2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }


        public string Members{ get; set; }
    }
}