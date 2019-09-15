using System;
using System.Collections.Generic;
using System.Linq;

namespace NCaptcha.Abstractions
{
    public class CaptchaResult
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public bool Failed { get; set; } = false;

        public string CaptchaCode { get; set; }

        public DateTime Timestamp { get; set; }

        public Dictionary<string, object> Properties
        {
            get
            {
                Dictionary<string, object> prop = new Dictionary<string, object>
                {
                    { "Failed", Failed },
                    { "CaptchaCode", CaptchaCode },
                    { "Timestamp", Timestamp }
                };

                return prop.Concat(_properties).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public object this[string key]
        {
            get { return _properties[key]; }
            set { _properties[key] = value; }
        }
    }
}
