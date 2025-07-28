using MailAutomation.Application.UserServices.Commands;
using MailAutomation.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Services.UserServices
{
    public class SignOutUser : ISignOutUser
    {
        private readonly SignInManager<User> _signInManager;

        public SignOutUser(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public void SignOut()
        {
            _signInManager.SignOutAsync();
        }
    }
}
