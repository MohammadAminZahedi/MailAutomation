using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Application.Common
{
    public class ResultDto
    {
        public bool State { get; set; }
        public string Code { get; set; }
        public Results Comment { get; set; }
        public List<string> Errors { get; set; }

        public ResultDto(bool state, Results comment)
        {
            State = state;
            Comment = comment;
        }

       

       
    }
    public enum Results
    {
        Success,
        Failure,
        DatabaseError,
        ApplicationError,
        UserAleardyExist,
        UserNotFound,
        SginInError,
        SignUpError,

        MailNotFound
    }

  
}
