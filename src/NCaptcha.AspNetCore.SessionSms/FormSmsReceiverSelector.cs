using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NCaptcha.Targets.Sms.Abstractions;

namespace NCaptcha.AspNetCore.SessionSms
{
    public class FormSmsReceiverSelector : ISmsReceiverSelector
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _phoneNumberFieldName = "phoneNumber";

        public FormSmsReceiverSelector(
            IHttpContextAccessor httpContextAccessor
        )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public FormSmsReceiverSelector(
            IHttpContextAccessor httpContextAccessor,
            string phoneNumberFieldName = "phoneNumber")
        {
            _httpContextAccessor = httpContextAccessor;
            _phoneNumberFieldName = phoneNumberFieldName;
        }

        public async Task<string> SelectAsync()
        {
            IFormCollection form = await _httpContextAccessor.HttpContext.Request.ReadFormAsync();
            KeyValuePair<string, StringValues> field = form.FirstOrDefault(x => x.Key.Equals(_phoneNumberFieldName, StringComparison.InvariantCultureIgnoreCase));
            return !field.Value.Any() ? string.Empty : field.Value.ToString();
        }
    }
}
