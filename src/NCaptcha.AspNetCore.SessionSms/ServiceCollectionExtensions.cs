using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NCaptcha.Builders;
using NCaptcha.Extensions;
using NCaptcha.State.Session;
using NCaptcha.Targets.Sms;
using NCaptcha.Targets.Sms.Abstractions;

namespace NCaptcha.AspNetCore.SessionSms
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessionBasedSmsCaptcha(this IServiceCollection services, string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ", int codeLength = 4)
        {
            services.AddSessionBasedSmsCaptcha(null, letters, codeLength);

            return services;
        }

        public static IServiceCollection AddSessionBasedSmsCaptcha(this IServiceCollection services, Action<INCaptchaBuilder> captchaBuilderAction, string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ", int codeLength = 4)
        {
            services.AddNCaptcha<SessionBasedSmsCaptchaGenerator>(builder =>
            {
                builder.UseBasicLetterCaptchaCode(letters, codeLength)
                    .UseSession();

                builder.Services.TryAddSingleton<ISmsReceiverSelector, FormSmsReceiverSelector>();
                builder.Services.TryAddSingleton<ISmsContentGenerator, CaptchaCodeSmsContentGenerator>();
                builder.Services.TryAddSingleton<ISmsSender, ConsoleSmsSender>();

                captchaBuilderAction?.Invoke(builder);
            });

            return services;
        }
    }
}
