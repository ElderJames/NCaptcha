using System;
using System.Collections.Generic;
using System.Text;

namespace NCaptcha.Targets.Sms.Aliyun
{
    public class AliyunSmsOptions
    {
        public string AccountKeyId { get; set; }
        public string AccessKeySecret { get; set; }
        public string SmsServiceSignName { get; set; }
        public string SmsServiceTemplateCode { get; set; }
    }
}
