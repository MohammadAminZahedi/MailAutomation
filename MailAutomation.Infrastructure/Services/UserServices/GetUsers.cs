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
    public class GetUsers : IGetUsers
    {
        private readonly UserManager<User> _userManager;

        public GetUsers(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _userManager.Users
                .Select(u => new UserDto()
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName

                });

        }
    }
}
