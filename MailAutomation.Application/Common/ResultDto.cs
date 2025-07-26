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
        public List<string> Errors { get; set; }

        public ResultDto(bool state, string code)
        {
            State = state;
            Code = code;
        }

        public ResultDto(bool state, string code, List<string> errors) : this(state, code)
        {
            Errors = errors;
        }
    }
}
