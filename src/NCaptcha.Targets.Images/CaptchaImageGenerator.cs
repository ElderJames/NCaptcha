using System.IO;
using System.Threading.Tasks;

namespace NCaptcha.Targets.Images
{
    public class CaptchaImageGenerator : ICaptchaImageGenerator
    {
        private readonly int _width;
        private readonly int _height;

        public CaptchaImageGenerator(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public Task<byte[]> GetImageAsync(string captchaCode)
        {
            using (MemoryStream ms = DrawingHelper.CreateImage(captchaCode, _height, _width))
            {
                return Task.FromResult(ms.ToArray());
            }
        }
    }
}
