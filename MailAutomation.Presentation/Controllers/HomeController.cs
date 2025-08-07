using MailAutomation.Application.UserServices.Commands;
using MailAutomation.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MailAutomation.Presentation.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        private readonly ISignOutUser _signOutUser;

        public HomeController(ISignOutUser signOutUser)
        {
            _signOutUser = signOutUser;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            _signOutUser.SignOut();
            return RedirectToAction("SignIn","Accounting");
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
