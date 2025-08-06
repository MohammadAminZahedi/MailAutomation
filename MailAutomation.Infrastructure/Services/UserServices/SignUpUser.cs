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
                UserName = user.UserName.Trim(),
                FirstName = user.FirstName.Trim(),
                LastName = user.LastName.Trim()
            };

            if (_userManager.Users.Any(x => x.NormalizedUserName == user.UserName.ToUpper()) == false)
            {
                var result = _userManager.CreateAsync(userToSignUp, user.Password).Result;

                if (result.Succeeded)
                    return new ResultDto(true, Results.Success);
                else
                    return new ResultDto(false, Results.SignUpError);
            }
            else
            {
                return new ResultDto(false, Results.UserAleardyExist);
            }




        }
    }
}
