using System.Threading.Tasks;
using NCaptcha.Abstractions;

namespace NCaptcha.Core
{
    public class DefaultCaptchaValidator : ICaptchaValidator
    {
        private readonly ICaptchaCodeStorage _captchaCodeStorage;

        public DefaultCaptchaValidator(ICaptchaCodeStorage captchaCodeStorage)
        {
            _captchaCodeStorage = captchaCodeStorage;
        }

        public ValueTask<bool> ValidateAsync(string userInputCaptcha)
        {
            return _captchaCodeStorage.ValidateAsync(userInputCaptcha);
        }
    }
}
