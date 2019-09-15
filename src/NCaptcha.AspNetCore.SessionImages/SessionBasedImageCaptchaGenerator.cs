using System;
using System.Threading.Tasks;
using NCaptcha.Abstractions;
using NCaptcha.Targets.Images;

namespace NCaptcha.AspNetCore.SessionImages
{
    public class SessionBasedImageCaptchaGenerator : ICaptchaGenerator
    {
        private readonly ICaptchaCodeGenerator _captchaGenerator;
        private readonly ICaptchaImageGenerator _captchaImageGenerator;
        private readonly ICaptchaCodeStorage _captchaCodeStorage;

        public SessionBasedImageCaptchaGenerator(
            ICaptchaCodeGenerator captchaGenerator,
            ICaptchaImageGenerator captchaImageGenerator,
            ICaptchaCodeStorage captchaCodeStorage)
        {
            _captchaGenerator = captchaGenerator;
            _captchaImageGenerator = captchaImageGenerator;
            _captchaCodeStorage = captchaCodeStorage;
        }

        public async Task<CaptchaResult> GenerateCaptchaAsync()
        {
            string captchaCode = await _captchaGenerator.GenerateCaptchaCodeAsync();
            byte[] bytes = await _captchaImageGenerator.GetImageAsync(captchaCode);
            await _captchaCodeStorage.SaveAsync(captchaCode);

            return new FileCaptchaResult
            {
                CaptchaCode = captchaCode,
                CaptchaByteData = bytes,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}
