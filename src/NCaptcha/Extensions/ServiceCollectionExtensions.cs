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
            where TCaptcha : class, ICaptchaGenerator
        {
            services.TryAddSingleton<ICaptchaCodeGenerator>(new BasicLetterCodeGenerator(letters, codeLength));
            services.TryAddSingleton<ICaptchaCodeStorage, InMemoryStorage>();
            services.TryAddSingleton<ICaptchaValidator, DefaultCaptchaValidator>();
            services.TryAddSingleton<ICaptchaGenerator, TCaptcha>();

            return services;
        }

        public static IServiceCollection AddNCaptcha<TCaptcha>(this IServiceCollection services,
            Action<INCaptchaBuilder> builderAction)
            where TCaptcha : class, ICaptchaGenerator
        {
            var builder = new NCaptchaBuilder(services);
            builderAction(builder);

            services.AddNCaptcha<TCaptcha>();

            return services;
        }

        public static IServiceCollection AddNCaptcha(this IServiceCollection services,
            Action<INCaptchaBuilder> builderAction)
        {
            services.AddNCaptcha<DefaultCaptchaGenerator>(builderAction);

            return services;
        }
    }
}
