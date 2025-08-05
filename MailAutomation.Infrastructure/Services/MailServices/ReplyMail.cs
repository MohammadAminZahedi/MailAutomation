using MailAutomation.Application.Common;
using MailAutomation.Application.MailServices.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Services.MailServices
{
    public class ReplyMail : IReplyMail
    {
        private readonly Context _context;

        public ReplyMail(Context context)
        {
            _context = context;
        }

        public ResultDto ReplyTo(string mailId, string parentMailId)
        {
            var foundMail = _context.Mails.SingleOrDefault(x => x.MailId == mailId);
            if (foundMail != null)
            {
                foundMail.ParentMailId = parentMailId;
                var stateChanges=_context.SaveChanges();
                if (stateChanges > 0)
                    return new ResultDto(true, Results.Success);
                else
                    return new ResultDto(false, Results.DatabaseError);
            }
            else
            {
                return new ResultDto(false, Results.MailNotFound);
            }
        }
    }
}
