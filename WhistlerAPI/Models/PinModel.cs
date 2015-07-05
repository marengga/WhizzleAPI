using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class PinModel
    {
        public Guid PinBoardId { get; set; }
        public Guid TeamId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid CreatedById { get; set; }
        public Guid AssigneeId { get; set; }
        public string DueDate { get; set; }
        public int Priority { get; set; }
        public int StatusCode { get; set; }
    }
}