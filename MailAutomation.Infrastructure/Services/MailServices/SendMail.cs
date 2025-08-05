using MailAutomation.Application.Common;
using MailAutomation.Application.MailServices.Commands;
using MailAutomation.Application.UserServices.Queries;
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
        private readonly IGetUser _getUser;

        public SendMail(Context context, IGetUser getUser)
        {
            _context = context;
            _getUser = getUser;
        }

        public ResultDto Send(MailDto mail)
        {
            var receiver = _getUser.GetUserByUserName(mail.ReceiverUserName);

            if (receiver == null)
            {
                return new ResultDto(false, Results.UserNotFound);
            }

            


            Mail mailToSend = new Mail()
            {
                MailId = Guid.NewGuid().ToString(),
                Title = mail.Title,
                Body = mail.Body,
                Date = DateTime.Now,
                SenderId = mail.SenderId,
                ReceiverId = receiver.UserId,
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
