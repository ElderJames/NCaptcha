using System.Threading.Tasks;

namespace NCaptcha.Abstractions
{
    public interface ICaptcha
    {
        Task<CaptchaResult> GenerateCaptchaAsync();

        ValueTask<bool> ValidateCaptchaAsync(string userInputCaptcha);
    }
}
