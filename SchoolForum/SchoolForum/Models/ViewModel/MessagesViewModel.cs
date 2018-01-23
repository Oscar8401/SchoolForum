using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolForum.Models.ViewModel
{
    public class MessagesViewModel
    {
        public int Id { get; set; }

         
        public string Title { get; set; }

        public string Text { get; set; }

        //public string Textreply { get; set; }

        //[Column(TypeName = "datetime2")]
        //[DisplayName("PostingDate")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime ReplyingDate { get; set; }

        //public string UserReply { get; set; }

        //public int NumberOfReply { get; set; }

        public int NumberOfMessages { get; set; }

         public string User { get; set; }
 
        [Column(TypeName = "datetime2")]
        [DisplayName("PostingDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostingDate { get; set; }

        public string CategoryName { get; set; }
        public IEnumerable<Categories> CategoryNames { get; set; }

        public MessagesViewModel(){}

        public MessagesViewModel(Reply r, Message m, ApplicationUser a, Categories c)
        {
            Title = m.Title;
            Text = m.Text;
            NumberOfMessages = m.NumberOfMessage;
            User = a.FullName;
            PostingDate = m.PostingDate;
            //Textreply = r.TextReply;
            //ReplyingDate = r.ReplyingDate;
            //UserReply = r.userReply;
            //NumberOfReply = r.NumberOfReply;
            CategoryName = c.Name;
            

        }
    }
}