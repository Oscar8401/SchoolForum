using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolForum.Models
{
    public class Categories
    {
        public int Id{ get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public string Members{ get; set; }
    }
}