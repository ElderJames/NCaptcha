using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NCaptcha.Targets.Email.Abstractions;

namespace NCaptcha.AspNetCore.SessionEmail
{
    public class FormEmailReceiverSelector : IEmailReceiverSelector
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _emailFieldName = "Email";

        public FormEmailReceiverSelector(
            IHttpContextAccessor httpContextAccessor
           )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public FormEmailReceiverSelector(
            IHttpContextAccessor httpContextAccessor,
            string emailFieldName = "Email")
        {
            _httpContextAccessor = httpContextAccessor;
            _emailFieldName = emailFieldName;
        }

        public async Task<string> SelectAsync()
        {
            IFormCollection form = await _httpContextAccessor.HttpContext.Request.ReadFormAsync();
            KeyValuePair<string, StringValues> field = form.FirstOrDefault(x => x.Key.Equals(_emailFieldName, StringComparison.InvariantCultureIgnoreCase));
            if (!field.Value.Any())
            {
                return string.Empty;
            }
            return field.Value.ToString();
        }
    }
}
