using MailAutomation.Application.Common;
using MailAutomation.Application.UserServices.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MailAutomation.Presentation.Controllers
{
    public class AccountingController : Controller
    {
        private readonly ISignUpUser _signUpUser;

        public AccountingController(ISignUpUser signUpUser)
        {
            _signUpUser = signUpUser;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserDto userDto)
        {
            var result = _signUpUser.SignUp(userDto);
            ViewBag.ResultState = result.State;
            ViewBag.Result = result.Comment;
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

    }
}
