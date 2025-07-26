using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Domain
{
    public class Mail
    {
        public string MailId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public bool IsRemovedFromSender { get; set; }
        public bool IsRemovedFromReceiver { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
