using System.Threading.Tasks;

namespace NCaptcha.Abstractions
{
    public interface ICaptchaValidator
    {
        ValueTask<bool> ValidateAsync(string userInputCaptcha);
    }
}
