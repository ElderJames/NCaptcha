using Microsoft.Extensions.DependencyInjection.Extensions;
using NCaptcha.Abstractions;
using NCaptcha.Builders;

namespace NCaptcha.State.Session
{
    public static class NCaptchaBuilderExtensions
    {
        public static INCaptchaBuilder UseSession(this INCaptchaBuilder builder)
        {
            builder.Services.TryAddSingleton<ICaptchaCodeStorage, SessionCaptchaCodeStorage>();
            return builder;
        }
    }
}
