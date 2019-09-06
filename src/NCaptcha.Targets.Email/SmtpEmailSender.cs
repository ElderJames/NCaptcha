using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using NCaptcha.Targets.Email.Abstractions;

namespace NCaptcha.Targets.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly EmailCaptchaOptions _emailCaptchaOptions;
        private readonly ILogger _logger;

        public SmtpEmailSender(
            ILogger<SmtpEmailSender> logger,
            IOptions<EmailCaptchaOptions> emailCaptchaOptions)
        {
            _logger = logger;
            _emailCaptchaOptions = emailCaptchaOptions.Value;
        }

        public async Task SendAsync(string emailTo, string subject, string body)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    var mimeMessage = new MimeMessage();
                    mimeMessage.From.Add(new MailboxAddress(_emailCaptchaOptions.MailFromName, _emailCaptchaOptions.MailFromAddress));
                    mimeMessage.To.Add(new MailboxAddress(emailTo));
                    mimeMessage.Subject = subject;
                    mimeMessage.Body = new TextPart(TextFormat.Html) { Text = body };

                    await smtpClient.ConnectAsync(_emailCaptchaOptions.ServerHost, _emailCaptchaOptions.ServerSslPort, useSsl: true);
                    if (!string.IsNullOrEmpty(_emailCaptchaOptions.UserName) && !string.IsNullOrEmpty(_emailCaptchaOptions.Password))
                    {
                        await smtpClient.AuthenticateAsync(_emailCaptchaOptions.UserName, _emailCaptchaOptions.Password);
                    }

                    await smtpClient.SendAsync(mimeMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The Email send failed");
                throw;
            }
        }
    }
}
