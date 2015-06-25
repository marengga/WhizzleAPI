using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhizzleAPI.Models;

namespace WhizzleAPI.Controllers
{
    public class MessageController : ApiController
    {
        static readonly IMessageRepository repo = new MessageRepository();
        public class MessageParam
        {
            public Guid userId { get; set; }
            public Guid friendId { get; set; }
            public Guid teamId { get; set; }
        }

        [Route("api/message/{type}"), HttpPost]
        public List<MessageModel> GetMessage(string type, MessageParam par)
        {
            Guid userId = par.userId;
            Guid friendId = par.friendId;
            Guid teamId = par.teamId;
            switch (type)
            {
                case "system" :
                    return repo.GetSystemMessage(userId);
                case "private" :
                    return repo.GetPrivateChat(userId, friendId);
                case "team" :
                    return repo.GetTeamChat(teamId);
                default :
                    return null;
            }
        }
    }
}
