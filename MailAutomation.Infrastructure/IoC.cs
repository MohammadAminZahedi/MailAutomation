using MailAutomation.Application.MailServices.Commands;
using MailAutomation.Application.MailServices.Queries;
using MailAutomation.Application.UserServices.Commands;
using MailAutomation.Application.UserServices.Queries;
using MailAutomation.Domain;
using MailAutomation.Infrastructure.Services.MailServices;
using MailAutomation.Infrastructure.Services.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAutomation.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            #region Add Services
            //User
            services.AddTransient<ISignInUser, SignInUser>();
            services.AddTransient<ISignUpUser, SignUpUser>();
            services.AddTransient<ISignOutUser, SignOutUser>();
            services.AddTransient<IGetUser, GetUser>();
            services.AddTransient<IGetUsers,GetUsers>();

            //Mail
            services.AddTransient<ISendMail, SendMail>();
            services.AddTransient<IRemoveMail, RemoveMail>();
            services.AddTransient<IRestoreMail, RestoreMail>();
            services.AddTransient<ISentMails, SentMails>();
            services.AddTransient<IReceivedMails, ReceivedMails>();
            services.AddTransient<IRemovedMails, RemovedMails>();
            services.AddTransient<ISearchedMails, SearchedMails>();
            services.AddTransient<IGetMail, GetMail>();
            #endregion

            services.AddDbContext<Context>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
