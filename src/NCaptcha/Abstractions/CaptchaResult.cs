using System;
using System.Collections.Generic;

namespace NCaptcha.Abstractions
{
    public class CaptchaResult
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public bool Failed { get; set; } = false;

        public string CaptchaCode { get; set; }

        public DateTime Timestamp { get; set; }

        public object this[string key]
        {
            get { return _properties[key]; }
            set { _properties[key] = value; }
        }
    }
}
