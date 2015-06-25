using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class MessageModel
    {
        public Guid MessageId { get; set; }
        public Guid Sender { get; set; }
        public string Sent { get; set; }
        public string Received { get; set; }
        public Guid RecipientUser { get; set; }
        public Guid RecipientTeam { get; set; }
        public string Message { get; set; }
        public string Expired { get; set; }
        public int StatusCode { get; set; }
    }
}