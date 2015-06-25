using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class LibraryModel
    {
        public System.Guid LibraryId { get; set; }
        public int Category { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}