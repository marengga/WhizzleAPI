using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class TeamModel
    {
        public String Name { get; set; }
        public System.Guid TeamId { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
    }
}