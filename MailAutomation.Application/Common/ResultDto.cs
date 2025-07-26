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
        public string Comment { get; set; }
        public List<string> Errors { get; set; }

        public ResultDto(bool state, string code, string comment)
        {
            State = state;
            Code = code;
            Comment = comment;
        }

        public ResultDto(bool state, string code, string comment, List<string> errors) : this(state, code, comment)
        {
            Errors = errors;
        }
    }
}
