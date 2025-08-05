using MailAutomation.Application.Common;
using MailAutomation.Application.MailServices.Commands;
using MailAutomation.Application.MailServices.Queries;
using MailAutomation.Application.UserServices.Queries;
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
        private readonly ISendMail _sendMail;
        private readonly IGetUsers _getUsers;
        private readonly IGetUser _getUser;

        public MailController(IReceivedMails receivedMails, ISentMails sentMails, IRemovedMails removedMails, ISendMail sendMail, IGetUsers getUsers, IGetUser getUser)
        {
            _receivedMails = receivedMails;
            _sentMails = sentMails;
            _removedMails = removedMails;
            _sendMail = sendMail;
            _getUsers = getUsers;
            _getUser = getUser;
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

        [HttpGet]
        public JsonResult GetUsers()
        {
            return Json(_getUsers.GetAllUsers().Select(u => u.UserName).ToList());
        }

        public IActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compose(MailDto mailDto)
        {
            MailDto mailToSend = new MailDto()
            {
                Title = mailDto.Title,
                Body = mailDto.Body.Trim(),
                SenderId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                ReceiverUserName = mailDto.ReceiverUserName
            };
            var result = _sendMail.Send(mailToSend);
            if (result.State)
            {
                return RedirectToAction("Outbox", "Mail");
            }
            else
            {

                return View(mailDto);
            }
        }

    }
}
