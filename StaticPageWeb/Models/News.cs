using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaticPageWeb.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Author { get; set;}
        public DateTime ReleaseTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}