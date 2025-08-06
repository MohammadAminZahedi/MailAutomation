using MailAutomation.Application.Common;
using MailAutomation.Application.MailServices.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Services.MailServices
{
    public class GetReplies : IGetReplies
    {
        private readonly Context _context;

        public GetReplies(Context context)
        {
            _context = context;
        }

        public IEnumerable<MailDto> GetAllReplies(string parentMailId)
        {
            var replies = _context.Mails
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => m.ParentMailId == parentMailId)
                .Select(m => new MailDto()
                {
                    MailId = m.MailId,
                    Title = m.Title,
                    Body = m.Body,
                    Date = m.Date,
                    SenderId = m.SenderId,
                    SenderUserName = m.Sender.UserName,
                    SenderFirstName = m.Sender.FirstName,
                    SenderLastName = m.Sender.LastName,
                    ReceiverId = m.ReceiverId,
                    ReceiverUserName = m.Receiver.UserName,
                    ReceiverFirstName = m.Receiver.FirstName,
                    ReceiverLastName = m.Receiver.LastName,
                    ParentMailId = m.ParentMailId,
                    IsRemovedFromSender = m.IsRemovedFromSender,
                    IsRemovedFromReceiver = m.IsRemovedFromReceiver
                });
            return replies;
        }
    }
}
