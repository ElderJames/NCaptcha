using System;
using Microsoft.Extensions.DependencyInjection;
using NCaptcha.Builders;
using NCaptcha.Targets.Sms.Abstractions;

namespace NCaptcha.Targets.Sms.Aliyun
{
    public static class NCaptchaBuilderExtensions
    {
        public static INCaptchaBuilder UseAliyunSmsCaptcha(this INCaptchaBuilder builder, Action<AliyunSmsOptions> configureOptions)
        {
            builder.Services.AddHttpClient("AliyunSms");
            builder.Services.PostConfigure(configureOptions);
            builder.Services.AddSingleton<AliyunSmsSdk>();
            builder.Services.AddSingleton<ISmsSender, AliyunSmsSender>();

            return builder;
        }
    }
}
