using Microsoft.Extensions.DependencyInjection;

namespace NCaptcha.Builders
{
    public interface INCaptchaBuilder
    {
        IServiceCollection Services { get; }
    }
}
