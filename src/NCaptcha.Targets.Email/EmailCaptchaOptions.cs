namespace NCaptcha.Targets.Email
{
    public class EmailCaptchaOptions
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string MailFromName { get; set; }

        public string MailFromAddress { get; set; }

        public string ServerHost { get; set; }

        public int ServerSslPort { get; set; }
    }
}
