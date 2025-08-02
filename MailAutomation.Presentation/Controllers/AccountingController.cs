using MailAutomation.Application.Common;
using MailAutomation.Application.UserServices.Commands;
using MailAutomation.Application.UserServices.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MailAutomation.Presentation.Controllers
{
    public class AccountingController : Controller
    {
        private readonly ISignUpUser _signUpUser;
        private readonly ISignInUser _signInUser;

        public AccountingController(ISignUpUser signUpUser, ISignInUser signInUser)
        {
            _signUpUser = signUpUser;
            _signInUser = signInUser;
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

        [HttpPost]
        public IActionResult SignIn(UserDto userDto)
        {
            var result = _signInUser.SignIn(userDto);
            if (result.State)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ResultState = result.State;
                return View();
            }

        }

    }
}
