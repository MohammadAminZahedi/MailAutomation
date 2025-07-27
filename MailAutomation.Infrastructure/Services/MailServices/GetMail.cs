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
    public class GetMail : IGetMail
    {
        private readonly Context _context;

        public GetMail(Context context)
        {
            _context = context;
        }

        public MailDto GetMailById(string mailId)
        {
            var foundMail = _context.Mails
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .SingleOrDefault(x => x.MailId == mailId);

            if (foundMail != null)
            {
                MailDto mail = new MailDto()
                {
                    MailId = foundMail.MailId,
                    Title = foundMail.Title,
                    Body = foundMail.Body,
                    Date = foundMail.Date,
                    SenderId = foundMail.SenderId,
                    SenderUserName = foundMail.Sender.UserName,
                    SenderFirstName = foundMail.Sender.FirstName,
                    SenderLastName = foundMail.Sender.LastName,
                    ReceiverId = foundMail.ReceiverId,
                    ReceiverUserName = foundMail.Receiver.UserName,
                    ReceiverFirstName = foundMail.Receiver.FirstName,
                    ReceiverLastName = foundMail.Receiver.LastName,
                    IsRemovedFromSender = foundMail.IsRemovedFromSender,
                    IsRemovedFromReceiver = foundMail.IsRemovedFromReceiver
                };

                return mail;
            }
            else
                return null;
        }
    }
}
