using System.Collections.Generic;
using System.Threading.Tasks;
using NCaptcha.Abstractions;

namespace NCaptcha.Core
{
    public class InMemoryStorage : ICaptchaCodeStorage
    {
        private static readonly IList<string> s_items = new List<string>();

        public ValueTask<bool> SaveAsync(string captchaCode)
        {
            s_items.Add(captchaCode);
            return new ValueTask<bool>(true);
        }

        public ValueTask<bool> Validate(string captchaCode)
        {
            return new ValueTask<bool>(s_items.Remove(captchaCode));
        }
    }
}
