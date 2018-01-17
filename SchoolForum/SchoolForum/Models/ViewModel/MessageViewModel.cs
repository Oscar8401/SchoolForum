using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;


namespace SchoolForum.Models.ViewModel
{
    public class MessageViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Textreply { get; set; }

        public DateTime ReplyingDate { get; set; }

        public DateTime PostingDate { get; set; }

        //public ICollection<Message> message { get; set; }
        //public ICollection<Reply> replies { get; set; }
        //public ICollection<Categories> categories { get; set; }

        public MessageViewModel() {}

        public MessageViewModel(Message x, Reply y)
        {
            Title = x.Title;
            Text = x.Text;
            PostingDate = x.PostingDate;
            Textreply = y.TextReply;
            ReplyingDate = y.ReplyingDate;
        }


    }
}