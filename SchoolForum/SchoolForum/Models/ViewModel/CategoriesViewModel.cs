using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolForum.Models.ViewModel
{
    public class CategoriesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Members { get; set; }

        public int MemebersCount { get; set; }

        public int NumberOfMessages { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime CreatingTime { get; set; }

        public string User { get; set; }

        public CategoriesViewModel(){}

        public CategoriesViewModel(ApplicationUser a, Categories c, Message m)
        {
            Id = c.Id;
            Name = c.Name;
            Description = c.Description;
            CreatingTime = c.CreatingTime;
            NumberOfMessages = m.NumberOfMessage;
            Members = a.FullName;
            User = a.FullName;
            MemebersCount = a.MembersCount;
        }
    }
}