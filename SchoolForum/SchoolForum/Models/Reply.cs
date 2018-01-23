using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Reply
    {
        public int Id { get; set; }

        public string TextReply { get; set; }

        public DateTime ReplyingDate { get; set; }

        public string userReply { get; set; }

        public int NumberOfReply { get; set; }



        //public ICollection<Message> Message { get; set; }
        public virtual Message messages { get; set; }
        //public ICollection<ApplicationUser> user { get; set; }
        public virtual ApplicationUser users { get; set; }
    }
}