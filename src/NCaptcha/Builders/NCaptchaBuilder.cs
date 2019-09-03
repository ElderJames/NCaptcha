using Microsoft.Extensions.DependencyInjection;

namespace NCaptcha.Builders
{
    public class NCaptchaBuilder : INCaptchaBuilder
    {
        public NCaptchaBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
