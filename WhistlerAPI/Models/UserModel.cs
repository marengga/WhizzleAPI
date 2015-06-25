using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public string NIP { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string IMEI { get; set; }
        public string Status { get; set; }
        public bool ShareLocation { get; set; }
        public string Location { get; set; }
        public DateTime LocationDate { get; set; }
        public string ImageUrl { get; set; }
    }
}