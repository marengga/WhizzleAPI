using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class ImageModel
    {
        public String type { get; set; }
        public System.Guid id { get; set; }
        public Image image { get; set; }
    }
}