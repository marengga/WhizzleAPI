using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhizzleAPI.Models
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        UserModel Login(string nip, string imei);
        List<UserModel> GetFriend(Guid userId);
        List<UserModel> GetTeamMember(Guid teamId);
    }
}