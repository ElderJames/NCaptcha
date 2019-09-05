using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NCaptcha.Abstractions;
using NCaptcha.Builders;
using NCaptcha.Core;

namespace NCaptcha.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNCaptcha<TCaptcha>(this IServiceCollection services, string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ", int codeLength = 4)
            where TCaptcha : class, ICaptcha
        {
            services.TryAddSingleton<ICaptchaCodeGenerator>(new BasicLetterCodeGenerator(letters, codeLength));
            services.TryAddSingleton<ICaptchaCodeStorage, InMemoryStorage>();
            services.TryAddSingleton<ICaptcha, TCaptcha>();

            return services;
        }

        public static IServiceCollection AddNCaptcha<TCaptcha>(this IServiceCollection services,
            Action<INCaptchaBuilder> builderAction)
            where TCaptcha : class, ICaptcha
        {
            var builder = new NCaptchaBuilder(services);
            builderAction(builder);

            services.AddNCaptcha<TCaptcha>();

            return services;
        }

        public static IServiceCollection AddNCaptcha(this IServiceCollection services,
            Action<INCaptchaBuilder> builderAction)
        {
            services.AddNCaptcha<DefaultCaptcha>(builderAction);

            return services;
        }
    }
}
