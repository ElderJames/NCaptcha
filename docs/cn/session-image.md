# 基于 Session 的图片验证码

0. 安装需要的 Nuget 包

    ```ps
        Install-Package NCaptcha.AspNetCore.SessionImages
    ```

1. 注册依赖注入服务

    ```cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSession();
        services.AddSessionBasedImageCaptcha();
    }
    ```

2. 配置 Session

    ```cs
    public void Configure(IApplicationBuilder app)
    {
        app.UseSession();
    }
    ```

3. 添加一个生成图片的 Api

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

4. 验证码验证

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
