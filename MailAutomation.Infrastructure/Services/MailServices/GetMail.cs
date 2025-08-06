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
                    ParentMailId = foundMail.ParentMailId,
                    Replies = _context.Mails.Where(m => m.ParentMailId == mailId)
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
                    }),
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
