using System.Threading.Tasks;

namespace NCaptcha.Abstractions
{
    public interface ICaptchaGenerator
    {
        Task<CaptchaResult> GenerateCaptchaAsync();
    }
}
