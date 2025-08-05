using MailAutomation.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Application.MailServices.Commands
{
    public interface IReplyMail
    {
        ResultDto ReplyTo(string mailId,string parentMailId);
    }
}
