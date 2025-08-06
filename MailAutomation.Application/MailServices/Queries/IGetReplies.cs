using MailAutomation.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Application.MailServices.Queries
{
    public interface IGetReplies
    {
        IEnumerable<MailDto> GetAllReplies(string parentMailId);
    }
}
