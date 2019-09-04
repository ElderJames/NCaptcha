using Microsoft.Extensions.DependencyInjection.Extensions;
using NCaptcha.Abstractions;
using NCaptcha.Builders;
using NCaptcha.Core;

namespace NCaptcha.Extensions
{
    public static class NCaptchaBuilderExtensions
    {
        public static INCaptchaBuilder UseBasicLetterCaptchaCode(this INCaptchaBuilder builder, string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ", int codeLength = 4)
        {
            builder.Services.TryAddSingleton<ICaptchaCodeGenerator>(new BasicLetterCodeGenerator(letters, codeLength));
            return builder;
        }
    }
}
