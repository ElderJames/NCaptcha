using System.Threading.Tasks;

namespace NCaptcha.Abstractions
{
    public interface ICaptchaCodeGenerator
    {
        Task<string> GenerateCaptchaCodeAsync();
    }
}
