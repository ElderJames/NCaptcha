using Microsoft.Extensions.DependencyInjection;
using NCaptcha.Builders;

namespace NCaptcha.Targets.Images
{
    public static class NCaptchaBuilderExtensions
    {
        public static INCaptchaBuilder UseImageCaptcha(this INCaptchaBuilder builder)
        {
            builder.Services.AddSingleton<ICaptchaImageGenerator, CaptchaImageGenerator>();
            return builder;
        }
    }
}
