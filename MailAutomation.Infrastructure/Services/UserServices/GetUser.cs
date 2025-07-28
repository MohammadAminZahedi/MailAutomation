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
    public class GetUser : IGetUser
    {
        private readonly UserManager<User> _userManger;

        public GetUser(UserManager<User> userManger)
        {
            _userManger = userManger;
        }

        public UserDto GetUserById(string id)
        {
            var user = _userManger.FindByIdAsync(id).Result;

            if (user != null)
            {
                return new UserDto()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
            else
            {
                return null;
            }

        }

        public UserDto GetUserByUserName(string userName)
        {
            var user = _userManger.FindByNameAsync(userName).Result;

            if (user != null)
            {
                return new UserDto()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
            else
            {
                return null;
            }
        }
    }
}
