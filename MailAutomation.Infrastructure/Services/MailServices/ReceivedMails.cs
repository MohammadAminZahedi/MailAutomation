using MailAutomation.Application.Common;
using MailAutomation.Application.MailServices.Queries;
using MailAutomation.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Services.MailServices
{
    public class ReceivedMails : IReceivedMails
    {
        private readonly Context _context;

        public ReceivedMails(Context context)
        {
            _context = context;
        }

        public IEnumerable<MailDto> GetReceivedMails(string userId)
        {
            var receivedMails = _context.Mails
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .Where(x => x.ReceiverId == userId && x.IsRemovedFromReceiver == false)
                .OrderByDescending(x=>x.Date)
                .Select(x => new MailDto()
                {
                    MailId = x.MailId,
                    Title = x.Title,
                    Body = x.Body,
                    Date = x.Date,
                    SenderId = x.SenderId,
                    SenderUserName = x.Sender.UserName,
                    SenderFirstName = x.Sender.FirstName,
                    SenderLastName = x.Sender.LastName,
                    ReceiverId = x.ReceiverId,
                    ReceiverUserName = x.Receiver.UserName,
                    ReceiverFirstName = x.Receiver.FirstName,
                    ReceiverLastName = x.Receiver.LastName,
                    IsRemovedFromSender = x.IsRemovedFromSender,
                    IsRemovedFromReceiver = x.IsRemovedFromReceiver
                });

            return receivedMails;
        }
    }
}
