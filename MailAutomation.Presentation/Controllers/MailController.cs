using MailAutomation.Application.MailServices.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Claims;

namespace MailAutomation.Presentation.Controllers
{
    public class MailController : Controller
    {
        private readonly IReceivedMails _receivedMails;
        private readonly ISentMails _sentMails;
        private readonly IRemovedMails _removedMails;

        public MailController(IReceivedMails receivedMails, ISentMails sentMails, IRemovedMails removedMails)
        {
            _receivedMails = receivedMails;
            _sentMails = sentMails;
            _removedMails = removedMails;
        }

        public IActionResult Inbox()
        {
            var receivedMails = _receivedMails.GetReceivedMails(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View(receivedMails);
        }

        public IActionResult Outbox()
        {
            var sentMails = _sentMails.GetSentMails(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return View(sentMails);
        }

        public IActionResult Trash()
        {
            var removedMails = _removedMails.GetRemovedMails(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return View(removedMails);
        }

    }
}
