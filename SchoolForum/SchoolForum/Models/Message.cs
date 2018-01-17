using SchoolForum.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Title should be between 3 and 30 charachters.")]
        [MaxWords(3, ErrorMessage = "Title should not be more than 3 words.")]
        [DisplayName("Title")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You should enter something.")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Too long text.")]
        [MaxWords(100, ErrorMessage = "Text can not be more than 2 words.")]
        [DisplayName("Text")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string Text { get; set; }

        public DateTime PostingDate { get; set; }



        public virtual ApplicationUser users { get; set; }
        public ICollection<Reply> replies { get; set; }
        //public virtual Reply replies { get; set; }
        public virtual Categories categories { get; set; }

    }
}