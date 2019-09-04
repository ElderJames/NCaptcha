using Microsoft.Extensions.DependencyInjection;
using NCaptcha.Builders;

namespace NCaptcha.Targets.Images
{
    public static class NCaptchaBuilderExtensions
    {
        public static INCaptchaBuilder UseImageCaptcha(this INCaptchaBuilder builder, int width, int height)
        {
            builder.Services.AddSingleton<ICaptchaImageGenerator>(new CaptchaImageGenerator(width, height));
            return builder;
        }
    }
}
