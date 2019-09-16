using System;
using System.Collections.Generic;
using System.Text;

namespace NCaptcha.Targets.Sms.Aliyun
{
    public class AliyunSmsException : Exception
    {
        public AliyunSmsResponse ResponseObject { get; set; }
        public string ResponseContent { get; set; }

        public AliyunSmsException(Exception exception,
            string response, AliyunSmsResponse responseObject)
            : base("Failed to request api with action SendSms with response "
                   + (response ?? string.Empty), exception)
        {
            ResponseContent = response;
            ResponseObject = responseObject;
        }
    }
}
