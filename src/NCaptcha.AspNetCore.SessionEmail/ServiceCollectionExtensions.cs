using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NCaptcha.Extensions;
using NCaptcha.State.Session;
using NCaptcha.Targets.Email;
using NCaptcha.Targets.Email.Abstractions;

namespace NCaptcha.AspNetCore.SessionEmail
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessionBasedEmailCaptcha(this IServiceCollection services, Action<EmailCaptchaOptions> optionAction, string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ", int codeLength = 4)
        {
            services.AddNCaptcha<SessionBasedEmailCaptcha>(builder =>
            {
                builder.UseBasicLetterCaptchaCode(letters, codeLength)
                    .UseEmailCaptcha(optionAction)
                    .UseSession();

                builder.Services.TryAddSingleton<IEmailReceiverSelector, FormEmailReceiverSelector>();
            });

            return services;
        }
    }
}
