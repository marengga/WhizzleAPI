using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhizzleAPI.DataAccess;

namespace WhizzleAPI.Models
{
    public class MessageRepository : IMessageRepository
    {
        WhizzleEntities we = new WhizzleEntities();
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
        private static String ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch.AddHours(7); // 7 untuk UTC hacks
            return ((long)elapsedTime.TotalMilliseconds).ToString();
        }
        public List<MessageModel> GetSystemMessage(Guid userId)
        {
            List<MessageModel> msg = new List<MessageModel>();
            var message = we.Messages.Where(m => m.Sender == Guid.Empty && (m.RecipientUser == null || m.RecipientUser == userId));

            foreach (var i in message)
            {
                msg.Add(new MessageModel
                {
                    Expired = ConvertToTimestamp(i.Expired ?? DateTime.Now.AddDays(5)),
                    Message = i.MessageContent,
                    MessageId = i.MessageId,
                    RecipientTeam = i.RecipientTeam ?? Guid.Empty,
                    RecipientUser = i.RecipientUser ?? Guid.Empty,
                    Sender = i.Sender ?? Guid.Empty,
                    Sent = ConvertToTimestamp(i.Sent ?? DateTime.Now),
                    StatusCode = i.StatusCode ?? 0
                });
            }
            return msg;
        }

        public List<MessageModel> GetPrivateChat(Guid userId, Guid friendId)
        {
            List<MessageModel> msg = new List<MessageModel>();
            var message = we.Messages
                .Where(m => (m.Sender == userId && m.RecipientUser == friendId) || (m.Sender == friendId && m.RecipientUser == userId))
                .Where(m=> m.Expired > DateTime.Now)
                .OrderBy(m => m.Sent);

            foreach (var i in message)
            {
                msg.Add(new MessageModel
                {
                    Expired = ConvertToTimestamp(i.Expired ?? DateTime.Now.AddDays(5)),
                    Message = i.MessageContent,
                    MessageId = i.MessageId,
                    RecipientTeam = i.RecipientTeam ?? Guid.Empty,
                    RecipientUser = i.RecipientUser ?? Guid.Empty,
                    Sender = i.Sender ?? Guid.Empty,
                    Sent = ConvertToTimestamp(i.Sent ?? DateTime.Now),
                    StatusCode = i.StatusCode ?? 0
                });
            }
            return msg;
        }

        public List<MessageModel> GetTeamChat(Guid groupId)
        {
            List<MessageModel> msg = new List<MessageModel>();
            var message = we.Messages
                .Where(m => m.RecipientTeam == groupId)
                .Where(m => m.Expired > DateTime.Now);

            foreach (var i in message)
            {
                msg.Add(new MessageModel
                {
                    Expired = ConvertToTimestamp(i.Expired ?? DateTime.Now.AddDays(5)),
                    Message = i.MessageContent,
                    MessageId = i.MessageId,
                    RecipientTeam = i.RecipientTeam ?? Guid.Empty,
                    RecipientUser = i.RecipientUser ?? Guid.Empty,
                    Sender = i.Sender ?? Guid.Empty,
                    Sent = ConvertToTimestamp(i.Sent ?? DateTime.Now),
                    StatusCode = i.StatusCode ?? 0
                });
            }
            return msg;
        }

        public MessageModel Add(MessageModel msg)
        {
            var m = new Message
            {
                Expired = new DateTime(),
                MessageContent = msg.Message,
                Received = new DateTime(),
                RecipientTeam = msg.RecipientTeam,
                RecipientUser = msg.RecipientUser,
                Sender = msg.Sender,
                Sent = new DateTime(),
                StatusCode = msg.StatusCode
            };

            we.Messages.Add(m);
            we.SaveChanges();

            return msg;
        }
    }
}