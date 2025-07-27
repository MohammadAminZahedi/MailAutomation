using MailAutomation.Application.Common;
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
    public class SignUpUser : ISignUpUser
    {
        private readonly UserManager<User> _userManager;

        public SignUpUser(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ResultDto SignUp(UserDto user)
        {
            User userToSignUp = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var result = _userManager.CreateAsync(userToSignUp, user.Passwrod).Result;

            if (result.Succeeded)
                return new ResultDto(true, "s_100");
            else
                return new ResultDto(false, "f_110", result.Errors.Select(e => e.Description).ToList());


        }
    }
}
