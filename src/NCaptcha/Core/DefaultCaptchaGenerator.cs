using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NCaptcha.Abstractions;

namespace NCaptcha.Core
{
    public class DefaultCaptchaGenerator : ICaptchaGenerator
    {
        private readonly ICaptchaCodeGenerator _captchaCodeGenerator;
        private readonly ICaptchaCodeStorage _captchaCodeStorage;
        private readonly ILogger _logger;

        public DefaultCaptchaGenerator(
            ICaptchaCodeGenerator captchaCodeGenerator,
            ICaptchaCodeStorage captchaCodeStorage,
            ILogger<DefaultCaptchaGenerator> logger)
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
    }
}
