using System.Threading.Tasks;
using NCaptcha.Abstractions;
using NCaptcha.Targets.Sms.Abstractions;

namespace NCaptcha.Targets.Sms
{
    public class CaptchaCodeSmsContentGenerator : ISmsContentGenerator
    {
        public Task<string> GenerateAsync(CaptchaResult captcha)
        {
            string content = $"Hello, your captcha code is: {captcha.CaptchaCode}. [via. NCaptcha]";
            return Task.FromResult(content);
        }
    }
}
