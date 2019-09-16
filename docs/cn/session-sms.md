# 基于 Session 的邮件验证码

0. 安装需要的 Nuget 包

    ```ps
        Install-Package NCaptcha.AspNetCore.SessionSms
        Install-Package NCaptcha.Targets.Sms.Aliyun
    ```

1. 在 `appsettings.json` 文件中添加配置。它取决于您选择的短信服务商：

    ```json
    "CaptchaAliyunSms": {
        "AccountKeyId": "",
        "AccessKeySecret": "",
        "SmsServiceSignName": "",
        "SmsServiceTemplateCode": ""
    }
    ```

1. 注册依赖注入服务

    ```cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSession();
        services.AddSessionBasedSmsCaptcha(builder =>
            builder.UseAliyunSmsCaptcha(Configuration.GetSection("CaptchaAliyunSms").Bind);
        );
    }
    ```

1. 配置 Session

    ```cs
    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
    }
    ```

1. 添加一个发送验证码的 Api

    ```cs
    public class LoginModel : PageModel
    {
        private readonly ICaptchaGenerator _captchaGenerator;

        public LoginModel(ICaptchaGenerator captchaGenerator)
        {
            _captchaGenerator = captchaGenerator;
        }

        public async Task OnPostSendCaptchaAsync() => await _captchaGenerator.GenerateCaptchaAsync();
    }

    ```

1. 验证码验证

    ```cs
    public class LoginModel : PageModel
    {
        private readonly ICaptchaValidator _captchaValidator;

        public LoginModel(ICaptchaValidator captchaValidator)
        {
            _captchaValidator = captchaValidator;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await _captchaValidator.ValidateAsync(Input.Captcha))
            {
                ModelState.AddModelError(nameof(InputModel.Captcha), "Invalid captcha.");
                return Page();
            }
        }
    }

    ```
