using System.Threading.Tasks;
using NCaptcha.Abstractions;

namespace NCaptcha.Targets.Sms.Abstractions
{
    public interface ISmsContentGenerator
    {
        Task<string> GenerateAsync(CaptchaResult captcha);
    }
}
