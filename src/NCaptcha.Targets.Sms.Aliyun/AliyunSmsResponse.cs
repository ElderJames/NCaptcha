using System;
using System.Collections.Generic;
using System.Text;

namespace NCaptcha.Targets.Sms.Aliyun
{
    public class AliyunSmsResponse
    {
        public string RequestId { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string BizId { get; set; }
    }
}
