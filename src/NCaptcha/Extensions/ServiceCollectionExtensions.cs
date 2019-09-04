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
        public static IServiceCollection AddNCaptcha(this IServiceCollection services, string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ", int codeLength = 4)
        {
            services.TryAddSingleton<ICaptchaCodeGenerator>(new BasicLetterCodeGenerator(letters, codeLength));
            services.TryAddSingleton<ICaptchaCodeStorage, InMemoryStorage>();
            services.TryAddSingleton<ICaptcha, DefaultCaptcha>();

            return services;
        }

        public static IServiceCollection AddNCaptcha(this IServiceCollection services, Action<INCaptchaBuilder> builderAction)
        {
            services.AddNCaptcha();

            var builder = new NCaptchaBuilder(services);
            builderAction(builder);

            return services;
        }
    }
}
