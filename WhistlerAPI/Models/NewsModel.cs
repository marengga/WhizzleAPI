using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class NewsModel
    {
        public System.Guid NewsId { get; set; }
        public string Author { get; set; }
        public string PublishedOn { get; set; }
        public int Category { get; set; }
        public string Title { get; set; }
        public string NewsContent { get; set; }
        public string ImageUrl { get; set; }
        public int StatusCode { get; set; }
    }
}