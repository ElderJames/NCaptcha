using System;
using System.Text;
using System.Threading.Tasks;
using NCaptcha.Abstractions;

namespace NCaptcha.Core
{
    public class BasicLetterCodeGenerator : ICaptchaCodeGenerator
    {
        private readonly string _letters;

        private readonly int _codeLength;

        public BasicLetterCodeGenerator(
            string letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ",
            int codeLength = 4
         )
        {
            _letters = letters;
            _codeLength = codeLength;
        }

        public Task<string> GenerateCaptchaCodeAsync()
        {
            var rand = new Random();
            int maxRand = _letters.Length - 1;

            var sb = new StringBuilder();
            for (int i = 0; i < _codeLength; i++)
            {
                int index = rand.Next(maxRand);
                sb.Append(_letters[index]);
            }

            return Task.FromResult(sb.ToString());
        }
    }
}
