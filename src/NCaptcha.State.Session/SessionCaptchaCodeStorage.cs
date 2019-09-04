using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NCaptcha.Abstractions;

namespace NCaptcha.State.Session
{
    public class SessionCaptchaCodeStorage : ICaptchaCodeStorage
    {
        public readonly string SessionName = "CaptchaCode";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionCaptchaCodeStorage(string sessionName, IHttpContextAccessor httpContextAccessor)
        {
            SessionName = sessionName;
            _httpContextAccessor = httpContextAccessor;
        }

        public SessionCaptchaCodeStorage(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ValueTask<bool> SaveAsync(string captcha)
        {
            _httpContextAccessor.HttpContext.Session.Set(SessionName, Encoding.UTF8.GetBytes(captcha));
            return new ValueTask<bool>(true);
        }

        public ValueTask<bool> ValidateAsync(string captcha)
        {
            if (string.IsNullOrEmpty(captcha))
                return new ValueTask<bool>(false);

            bool isValid = captcha.Equals(_httpContextAccessor.HttpContext.Session.GetString(SessionName), StringComparison.OrdinalIgnoreCase);
            _httpContextAccessor.HttpContext.Session.Remove(SessionName);

            return new ValueTask<bool>(isValid);
        }
    }
}
