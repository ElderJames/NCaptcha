# Email captcha base session

0. Install the required nuget package

    ```ps
        Install-Package NCaptcha.AspNetCore.SessionEmail
    ```

1. Add Options in the `appsettings.json` file.

    ```json
    "CaptchaEmail": {
        "UserName": "",
        "Password": "",
        "MailFromName": "",
        "MailFromAddress": "",
        "ServerHost": "",
        "ServerPort": 0,
        "UseSsl": false
    }
    ```

2. Register in DI

    ```cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSession();
        services.AddSessionBasedEmailCaptcha(Configuration.GetSection("CaptchaEmail").Bind);
    }
    ```

3. Configure the session

    ```cs
    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
    }
    ```

4. Add a API for sending captcha code

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

5. Validate the captcha

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
