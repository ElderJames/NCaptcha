using System.Threading.Tasks;

namespace NCaptcha.Targets.Images
{
    public interface ICaptchaImageGenerator
    {
        Task<byte[]> GetImageAsync(string captchaCode);
    }
}
