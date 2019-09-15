using Microsoft.Extensions.DependencyInjection;
using NCaptcha.Extensions;
using NCaptcha.State.Session;
using NCaptcha.Targets.Images;

namespace NCaptcha.AspNetCore.SessionImages
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSessionBasedImageCaptcha(this IServiceCollection services, int width = 100, int height = 40, string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ", int codeLength = 4)
        {
            services.AddNCaptcha<SessionBasedImageCaptchaGenerator>(builder =>
            {
                builder.UseBasicLetterCaptchaCode(letters, codeLength)
                    .UseImageCaptcha(width, height)
                    .UseSession();
            });

            return services;
        }
    }
}
