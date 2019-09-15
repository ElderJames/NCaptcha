using Microsoft.AspNetCore.Mvc;
using NCaptcha.Abstractions;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NCaptcha.AspNetCore.Extensions
{
    public static class CaptchaResultExtensions
    {
        public static async Task<IActionResult> GetCaptchaFileResultAsync(this ICaptchaGenerator captcha)
        {
            if (!(await captcha.GenerateCaptchaAsync() is FileCaptchaResult result))
                return null;

            return new FileContentResult(result.CaptchaByteData, MediaTypeNames.Image.Gif);
        }

        public static async Task<IActionResult> GetCaptchaJsonResultAsync(this ICaptchaGenerator captcha)
        {
            if (!(await captcha.GenerateCaptchaAsync() is CaptchaResult result))
                return null;

            return new OkObjectResult(result.Properties);
        }
    }
}
