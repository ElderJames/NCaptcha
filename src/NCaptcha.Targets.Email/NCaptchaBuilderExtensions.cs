using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NCaptcha.Builders;
using NCaptcha.Targets.Email.Abstractions;

namespace NCaptcha.Targets.Email
{
    public static class NCaptchaBuilderExtensions
    {
        public static INCaptchaBuilder UseEmailCaptcha(this INCaptchaBuilder builder, Action<EmailCaptchaOptions> optionAction)
        {
            EmailCaptchaOptions options = new EmailCaptchaOptions();
            optionAction(options);

            builder.Services.Configure(optionAction);

            builder.UseEmailCaptcha();
            return builder;
        }

        public static INCaptchaBuilder UseEmailCaptcha(this INCaptchaBuilder builder)
        {
            builder.Services.TryAddSingleton<IEmailSender, SmtpEmailSender>();
            builder.Services.AddSingleton<IEmailBodyGenerator, SimpleEmailBodyGenerator>();

            return builder;
        }
    }
}
