using MailAutomation.Application.Common;
using MailAutomation.Application.MailServices.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Services.MailServices
{
    public class RemoveMail : IRemoveMail
    {
        private readonly Context _context;

        public RemoveMail(Context context)
        {
            _context = context;
        }

        public ResultDto Remove(string mailId, string userId)
        {
            var mailToRemove = _context.Mails.SingleOrDefault(m => m.MailId == mailId);

            if (mailToRemove != null)
            {
                if (mailToRemove.SenderId == userId)
                    mailToRemove.IsRemovedFromSender = true;
                else
                    mailToRemove.IsRemovedFromReceiver = true;

                int stateChanges = _context.SaveChanges();

                if (stateChanges > 0)
                    return new ResultDto(true, "s_200");
                else return new ResultDto(false, "f_210");
            }
            else
            {
                return new ResultDto(false, "f_211"); //f_211 means fail, mail service, database operation, not found
            }

        }
    }
}
