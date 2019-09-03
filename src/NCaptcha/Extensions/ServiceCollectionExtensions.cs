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
        public static IServiceCollection AddNCaptcha(this IServiceCollection services, Action<INCaptchaBuilder> builderAction)
        {
            var builder = new NCaptchaBuilder(services);
            builderAction(builder);

            builder.UseBasicLetterCaptchaCode();

            services.TryAddSingleton<ICaptchaCodeStorage, InMemoryStorage>();
            services.TryAddSingleton<ICaptcha, DefaultCaptcha>();

            return services;
        }
    }
}
