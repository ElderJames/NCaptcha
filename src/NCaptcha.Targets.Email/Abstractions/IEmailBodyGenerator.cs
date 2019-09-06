using System.Threading.Tasks;
using NCaptcha.Abstractions;

namespace NCaptcha.Targets.Email.Abstractions
{
    public interface IEmailBodyGenerator
    {
        Task<string> GenerateSubjectAsync(CaptchaResult captcha);

        Task<string> GenerateBodyAsync(CaptchaResult captcha);
    }
}
