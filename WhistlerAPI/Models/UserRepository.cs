using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public class UserRepository : IUserRepository
    {
        WhizzleEntities we = new WhizzleEntities();
        String imgViewerBaseUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/api/image/user/";

        public List<UserModel> GetAll()
        {
            List<UserModel> us = new List<UserModel>();
            var user = from u in we.Users
                    join e in we.Employees on u.EmployeeId equals e.EmployeeId
                    select new{
                        u.UserId, e.EmployeeId, e.NIP, e.FullName, e.Department,
                        u.IMEI, u.Status, u.ShareLocation, u.Location, u.LocationDate,
                        ImageUrl = u.Avatar != null ? imgViewerBaseUrl+u.UserId.ToString() : ""
                    };
            foreach (var i in user)
            {
                us.Add(new UserModel
                {
                    Department = i.Department, EmployeeId = i.EmployeeId, FullName = i.FullName,
                    ImageUrl = i.ImageUrl, IMEI = i.IMEI, Location = i.Location, LocationDate = i.LocationDate ?? DateTime.MinValue,
                    NIP = i.NIP, ShareLocation = i.ShareLocation ?? false, Status = i.Status, UserId = i.UserId
                });
            }
            return us;
        }

        public UserModel Login(string nip, string imei)
        {
            var user = from u in we.Users
                       join e in we.Employees on u.EmployeeId equals e.EmployeeId
                       where e.NIP == nip && u.IMEI == imei
                       select new
                       {
                           u.UserId, e.EmployeeId, e.NIP, e.FullName, e.Department,
                           u.IMEI, u.Status, u.ShareLocation, u.Location, u.LocationDate,
                           ImageUrl = u.Avatar != null ? imgViewerBaseUrl + u.UserId.ToString() : ""
                       };
            if (user.Count() > 0)
            {
                var u = user.SingleOrDefault();
                return new UserModel
                {
                    Department = u.Department, EmployeeId = u.EmployeeId, FullName = u.FullName,
                    ImageUrl = u.ImageUrl, IMEI = u.IMEI, Location = u.Location,
                    LocationDate = u.LocationDate ?? DateTime.MinValue,
                    NIP = u.NIP, ShareLocation = u.ShareLocation ?? false,
                    Status = u.Status, UserId = u.UserId
                };
            }
            else
            {
                return null;
            }
        }

        public List<UserModel> GetFriend(Guid userId)
        {
            List<UserModel> us = new List<UserModel>();
            /*
SELECT u.UserId, e.EmployeeId, e.NIP, e.FullName, e.Department,
	u.IMEI, u.Status, u.ShareLocation, u.Location, u.LocationDate
FROM Whizzle.Connection c
INNER JOIN Whizzle.[User] u ON c.FriendId = u.UserId
INNER JOIN HumanResource.Employee e ON u.EmployeeId = e.EmployeeId
WHERE c.UserId = 'e7eb5c0f-03fe-e411-9386-1c750860c852'
UNION
SELECT u.UserId, e.EmployeeId, e.NIP, e.FullName, e.Department,
	u.IMEI, u.Status, u.ShareLocation, u.Location, u.LocationDate
FROM Whizzle.Connection c
INNER JOIN Whizzle.[User] u ON c.UserId = u.UserId
INNER JOIN HumanResource.Employee e ON u.EmployeeId = e.EmployeeId
WHERE c.FriendId = 'e7eb5c0f-03fe-e411-9386-1c750860c852'
             */
            var user = (from c in we.Connections
                       join u in we.Users on c.FriendId equals u.UserId
                       join e in we.Employees on u.EmployeeId equals e.EmployeeId
                       where c.UserId == userId
                       select new
                       {
                           u.UserId, e.EmployeeId, e.NIP, e.FullName, e.Department,
                           u.IMEI, u.Status, u.ShareLocation, u.Location, u.LocationDate,
                           ImageUrl = u.Avatar != null ? imgViewerBaseUrl + u.UserId.ToString() : ""
                       })
                       .Union
                       (
                       from c in we.Connections
                       join u in we.Users on c.UserId equals u.UserId
                       join e in we.Employees on u.EmployeeId equals e.EmployeeId
                       where c.FriendId == userId
                       select new
                       {
                           u.UserId, e.EmployeeId, e.NIP, e.FullName, e.Department,
                           u.IMEI, u.Status, u.ShareLocation, u.Location, u.LocationDate,
                           ImageUrl = u.Avatar != null ? imgViewerBaseUrl + u.UserId.ToString() : ""
                       }
                       );
            foreach (var i in user)
            {
                us.Add(new UserModel
                {
                    Department = i.Department, EmployeeId = i.EmployeeId, FullName = i.FullName,
                    ImageUrl = i.ImageUrl, IMEI = i.IMEI, Location = i.Location,
                    LocationDate = i.LocationDate ?? DateTime.MinValue,
                    NIP = i.NIP, ShareLocation = i.ShareLocation ?? false,
                    Status = i.Status, UserId = i.UserId
                });
            }
            return us;
        }
    }
}