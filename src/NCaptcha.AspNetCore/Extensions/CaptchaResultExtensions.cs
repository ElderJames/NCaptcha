using Microsoft.AspNetCore.Mvc;
using NCaptcha.Abstractions;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NCaptcha.AspNetCore.Extensions
{
    public static class CaptchaResultExtensions
    {
        public static async Task<FileResult> GetCaptchaFileResultAsync(this ICaptcha captcha)
        {
            CaptchaResult result = await captcha.GenerateCaptchaAsync();
            return new FileContentResult(result.CaptchaByteData, MediaTypeNames.Image.Gif);
        }
    }
}
