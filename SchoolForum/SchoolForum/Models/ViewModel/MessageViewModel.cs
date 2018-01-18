using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolForum.Models.ViewModel
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Textreply { get; set; }

        //[Column(TypeName = "datetime2")]
        //[DisplayName("ReplyingDate")]
        //public DateTime ReplyingDate { get; set; }

        [Column(TypeName = "datetime2")]
        [DisplayName("PostingDate")]
        public DateTime PostingDate { get; set; }
                                            
        //public ICollection<Message> message { get; set; }
        //public ICollection<Reply> replies { get; set; }
        //public ICollection<Categories> categories { get; set; }

        //public MessageViewModel() {}

        //public MessageViewModel(Message x, Reply y)
        //{
        //    Title = x.Title;
        //    Text = x.Text;
        //    PostingDate = x.PostingDate;
        //    Textreply = y.TextReply;
        //    ReplyingDate = y.ReplyingDate;
        //}


    }
}