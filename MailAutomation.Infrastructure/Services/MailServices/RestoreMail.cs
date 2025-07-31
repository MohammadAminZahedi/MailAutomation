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
    internal class RestoreMail : IRestoreMail
    {
        private readonly Context _context;

        public RestoreMail(Context context)
        {
            _context = context;
        }

        public ResultDto Restore(string mailId, string userId)
        {
            var mailToRestore = _context.Mails.SingleOrDefault(m => m.MailId == mailId);

            if (mailToRestore != null)
            {
                if (mailToRestore.SenderId == userId)
                    mailToRestore.IsRemovedFromSender = false;
                else
                    mailToRestore.IsRemovedFromReceiver = false;

                int stateChanges = _context.SaveChanges();

                if (stateChanges > 0)
                    return new ResultDto(true, Results.Success);
                else return new ResultDto(false, Results.DatabaseError);
            }
            else
            {
                return new ResultDto(false, Results.MailNotFound); 
            }
        }
    }
}
