using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NCaptcha.Abstractions;

namespace NCaptcha.Core
{
    public class DefaultCaptcha : ICaptcha
    {
        private readonly ICaptchaCodeGenerator _captchaCodeGenerator;
        private readonly ICaptchaCodeStorage _captchaCodeStorage;
        private readonly ILogger<DefaultCaptcha> _logger;

        public DefaultCaptcha(
            ICaptchaCodeGenerator captchaCodeGenerator,
            ICaptchaCodeStorage captchaCodeStorage,
            ILogger<DefaultCaptcha> logger)
        {
            _captchaCodeGenerator = captchaCodeGenerator;
            _captchaCodeStorage = captchaCodeStorage;
            _logger = logger;
        }

        public async Task<CaptchaResult> GenerateCaptchaAsync()
        {
            string captchaCode = await _captchaCodeGenerator.GenerateCaptchaCodeAsync();

            _logger.LogInformation("NCaptcha generate a code: {0} .", captchaCode);

            await _captchaCodeStorage.SaveAsync(captchaCode);
            return new CaptchaResult()
            {
                CaptchaCode = captchaCode,
                Timestamp = DateTime.UtcNow
            };
        }

        public async ValueTask<bool> ValidateCaptchaAsync(string userInputCaptcha)
        {
            bool isValid = await _captchaCodeStorage.ValidateAsync(userInputCaptcha);

            _logger.LogInformation("Captcha code validate {0}", isValid ? "success" : "failed");

            return isValid;
        }
    }
}
