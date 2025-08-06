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
    public class SearchedMails : ISearchedMails
    {
        private readonly Context _context;

        public SearchedMails(Context context)
        {
            _context = context;
        }

        public IEnumerable<MailDto> GetSearchedMailsBy(string key)
        {
            var searchedMails = _context.Mails
                 .Include(x => x.Sender)
                 .Include(x => x.Receiver)
                 .Where(x =>
                 x.Title.Contains(key) ||
                 x.Body.Contains(key) ||
                 x.Sender.UserName.Contains(key) ||
                 x.Sender.FirstName.Contains(key) ||
                 x.Sender.LastName.Contains(key) ||
                 x.Receiver.UserName.Contains(key) ||
                 x.Receiver.FirstName.Contains(key) ||
                 x.Receiver.LastName.Contains(key))
                .OrderByDescending(x => x.Date)
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
                     ParentMailId=x.ParentMailId,
                     IsRemovedFromSender = x.IsRemovedFromSender,
                     IsRemovedFromReceiver = x.IsRemovedFromReceiver
                 });

            return searchedMails;
        }
    }
}
