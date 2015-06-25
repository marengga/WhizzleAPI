using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public interface IMessageRepository
    {
        List<MessageModel> GetSystemMessage(Guid userId);
        List<MessageModel> GetPrivateChat(Guid userId, Guid friendId);
        List<MessageModel> GetTeamChat(Guid groupId);
        MessageModel Add(MessageModel msg);
    }
}
