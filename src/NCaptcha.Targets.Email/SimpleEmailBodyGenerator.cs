using System.Text;
using System.Threading.Tasks;
using NCaptcha.Abstractions;
using NCaptcha.Targets.Email.Abstractions;

namespace NCaptcha.Targets.Email
{
    public class SimpleEmailBodyGenerator : IEmailBodyGenerator
    {
        public Task<string> GenerateSubjectAsync(CaptchaResult captcha)
        {
            return Task.FromResult("NCaptcha Code Email");
        }

        public Task<string> GenerateBodyAsync(CaptchaResult captcha)
        {
            var body = new StringBuilder(300);

            body.Append("<!DOCTYPE html>");
            body.Append("<html><head>");
            body.Append(@"<meta http-equiv='Content-Type' content='text/html;charset = UTF-8'>");
            body.Append("<title>NCaptcha Code Email</title>");
            body.Append("</head>");
            body.Append("<body style='background:#fff;'>");
            body.Append("<h1>");
            body.Append("NCaptcha Code Email");
            body.Append("</h1>");
            body.Append($"<p>Your captcha Code is: <code>{captcha.CaptchaCode}</code></p>");
            body.Append("</body></html>");

            return Task.FromResult(body.ToString());
        }
    }
}
