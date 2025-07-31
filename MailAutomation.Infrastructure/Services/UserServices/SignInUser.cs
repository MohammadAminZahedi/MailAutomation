using MailAutomation.Application.Common;
using MailAutomation.Application.UserServices.Queries;
using MailAutomation.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure.Services.UserServices
{
    public class SignInUser : ISignInUser
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public SignInUser(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ResultDto SignIn(UserDto user)
        {
            var foundUsre = _userManager.FindByNameAsync(user.UserName).Result;

            if (foundUsre != null)
            {
                var result = _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, true).Result;

                if (result.Succeeded)
                    return new ResultDto(true, Results.Success);
                else
                    return new ResultDto(false, Results.SginInError);
            }
            else
                return new ResultDto(false, Results.UserNotFound);
        }
    }
}
