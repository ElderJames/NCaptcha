using NCaptcha.Abstractions;
using System;
using System.Threading.Tasks;
using NCaptcha.Targets.Sms.Abstractions;

namespace NCaptcha.AspNetCore.SessionSms
{
    public class SessionBasedSmsCaptchaGenerator : ICaptchaGenerator
    {
        private readonly ICaptchaCodeGenerator _captchaCodeGenerator;
        private readonly ICaptchaCodeStorage _captchaCodeStorage;
        private readonly ISmsContentGenerator _smsContentGenerator;
        private readonly ISmsReceiverSelector _smsReceiverSelector;
        private readonly ISmsSender _smsSender;

        public SessionBasedSmsCaptchaGenerator(ICaptchaCodeGenerator captchaCodeGenerator, ICaptchaCodeStorage captchaCodeStorage, ISmsSender smsSender, ISmsContentGenerator smsContentGenerator, ISmsReceiverSelector smsReceiverSelector)
        {
            _captchaCodeGenerator = captchaCodeGenerator;
            _captchaCodeStorage = captchaCodeStorage;
            _smsSender = smsSender;
            _smsContentGenerator = smsContentGenerator;
            _smsReceiverSelector = smsReceiverSelector;
        }

        public async Task<CaptchaResult> GenerateCaptchaAsync()
        {
            string captchaCode = await _captchaCodeGenerator.GenerateCaptchaCodeAsync();
            await _captchaCodeStorage.SaveAsync(captchaCode);

            CaptchaResult result = new CaptchaResult
            {
                CaptchaCode = captchaCode,
                Timestamp = DateTime.UtcNow
            };

            string phoneNumber = await _smsReceiverSelector.SelectAsync();
            string content = await _smsContentGenerator.GenerateAsync(result);
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(content))
            {
                result.Failed = true;
                return result;
            }
            await _smsSender.SendAsync(phoneNumber, content);
            return result;
        }
    }
}
