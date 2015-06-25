using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class MyTeamModel
    {
        public String name { get; set; }
        public System.Guid teamId { get; set; }
        public String description { get; set; }
    }
}