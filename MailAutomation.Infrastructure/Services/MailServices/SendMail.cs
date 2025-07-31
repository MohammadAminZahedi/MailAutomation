using MailAutomation.Application.Common;
using MailAutomation.Application.MailServices.Commands;
using MailAutomation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Services.MailServices
{
    public class SendMail : ISendMail
    {
        private readonly Context _context;

        public SendMail(Context context)
        {
            _context = context;
        }

        public ResultDto Send(MailDto mail)
        {
            Mail mailToSend = new Mail()
            {
                MailId = Guid.NewGuid().ToString(),
                Title = mail.Title,
                Body = mail.Body,
                Date = mail.Date,
                SenderId = mail.SenderId,
                ReceiverId = mail.ReceiverId,
                IsRemovedFromSender = mail.IsRemovedFromSender,
                IsRemovedFromReceiver = mail.IsRemovedFromReceiver
            };

            _context.Mails.Add(mailToSend);

            int stateChanges = _context.SaveChanges();

            if (stateChanges > 0)
                return new ResultDto(true, Results.Success);
            else
                return new ResultDto(false, Results.DatabaseError);
        }
    }
}
