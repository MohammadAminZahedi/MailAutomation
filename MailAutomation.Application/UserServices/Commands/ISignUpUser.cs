using MailAutomation.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Application.UserServices.Commands
{
    public interface ISignUpUser
    {
        ResultDto SignUp(UserDto user);
    }
}
