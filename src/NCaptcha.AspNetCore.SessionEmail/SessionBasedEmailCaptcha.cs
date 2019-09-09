using System;
using System.Threading.Tasks;
using NCaptcha.Abstractions;
using NCaptcha.Targets.Email.Abstractions;

namespace NCaptcha.AspNetCore.SessionEmail
{
    public class SessionBasedEmailCaptcha : ICaptcha
    {
        private readonly ICaptchaCodeGenerator _captchaGenerator;
        private readonly IEmailReceiverSelector _emailReceiverSelector;
        private readonly IEmailSender _emailSender;
        private readonly IEmailBodyGenerator _emailBodyGenerator;
        private readonly ICaptchaCodeStorage _captchaCodeStorage;

        public SessionBasedEmailCaptcha(
            ICaptchaCodeGenerator captchaGenerator,
            ICaptchaCodeStorage captchaCodeStorage,
            IEmailSender emailSender,
            IEmailReceiverSelector emailReceiverSelector,
            IEmailBodyGenerator emailBodyGenerator)
        {
            _captchaGenerator = captchaGenerator;
            _captchaCodeStorage = captchaCodeStorage;
            _emailSender = emailSender;
            _emailReceiverSelector = emailReceiverSelector;
            _emailBodyGenerator = emailBodyGenerator;
        }

        public async Task<CaptchaResult> GenerateCaptchaAsync()
        {
            string captchaCode = await _captchaGenerator.GenerateCaptchaCodeAsync();

            CaptchaResult result = new CaptchaResult
            {
                CaptchaCode = captchaCode,
                Timestamp = DateTime.UtcNow
            };

            string emailTo = await _emailReceiverSelector.SelectAsync();
            if (string.IsNullOrEmpty(emailTo))
            {
                result.Failed = true;
                return result;
            }

            string subject = await _emailBodyGenerator.GenerateSubjectAsync(result);
            string body = await _emailBodyGenerator.GenerateBodyAsync(result);
            await _emailSender.SendAsync(emailTo, subject, body);
            await _captchaCodeStorage.SaveAsync(captchaCode);

            return result;
        }

        public async ValueTask<bool> ValidateCaptchaAsync(string userInputCaptcha)
        {
            return await _captchaCodeStorage.ValidateAsync(userInputCaptcha);
        }
    }
}
