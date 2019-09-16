# Images captcha base session

0. Install the required nuget package

    ```ps
        Install-Package NCaptcha.AspNetCore.SessionImages
    ```

1. Register in DI

    ```cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSession();
        services.AddSessionBasedImageCaptcha();
    }
    ```

2. Configure the session

    ```cs
    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
    }
    ```

3. Add a API for getting captcha image

    ```cs
    public class LoginModel : PageModel
    {
        private readonly ICaptchaGenerator _captchaGenerator;

        public LoginModel(ICaptchaGenerator captchaGenerator)
        {
            _captchaGenerator = captchaGenerator;
        }

        public async Task<IActionResult> OnGetCaptchaAsync() => await _captchaGenerator.GetCaptchaFileResultAsync();
    }

    ```

4. Validate the captcha

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
