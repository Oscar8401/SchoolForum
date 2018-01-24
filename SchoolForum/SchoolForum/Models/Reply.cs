using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Reply
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Reply")]
        public string TextReply { get; set; }

        public DateTime ReplyDate { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string UserReply { get; set; }

        public int NumberOfReply { get; set; }



        //public ICollection<Message> Message { get; set; }
        public virtual Message messages { get; set; }
        //public ICollection<ApplicationUser> user { get; set; }
        public virtual ApplicationUser users { get; set; }
    }
}