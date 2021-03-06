﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.DataAccess;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class LoginDetail
    {
        public string nip { get; set; }
        public string imei { get; set; }
    }
    public class Identifier
    {
        public Guid userId { get; set; }
        public Guid teamId { get; set; }
    }
    public class UserController : ApiController
    {
        static readonly IUserRepository repo = new UserRepository();
        public List<UserModel> GetAll()
        {
            return repo.GetAll();
        }

        [Route("api/user/login"), HttpPost]
        public HttpResponseMessage PostLogin(LoginDetail l)
        {
            UserModel u = repo.Login(l.nip, l.imei);
            if (u == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found for the given details");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, u);
            }
        }

        [Route("api/user/friend"), HttpPost]
        public List<UserModel> PostFriend(Identifier id)
        {
            return repo.GetFriend(id.userId);
        }

        [Route("api/user/teammember"), HttpPost]
        public List<UserModel> PostTeamMember(Identifier id)
        {
            return repo.GetTeamMember(id.teamId);
        }
    }
}
