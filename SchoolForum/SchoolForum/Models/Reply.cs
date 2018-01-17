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

        public ICollection<Message> Message { get; set; }
        public ICollection<ApplicationUser> user { get; set; }
    }
}