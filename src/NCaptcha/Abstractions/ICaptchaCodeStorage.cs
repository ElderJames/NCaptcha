using System.Threading.Tasks;

namespace NCaptcha.Abstractions
{
    public interface ICaptchaCodeStorage
    {
        ValueTask<bool> SaveAsync(string captchaCode);

        ValueTask<bool> ValidateAsync(string captchaCode);
    }
}
