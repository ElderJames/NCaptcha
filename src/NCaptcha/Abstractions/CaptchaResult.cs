using System;

namespace NCaptcha.Abstractions
{
    public class CaptchaResult
    {
        public CaptchaResult()
        {
        }

        public CaptchaResult(CaptchaResult result)
        {
            Failed = result.Failed;
            CaptchaCode = result.CaptchaCode;
            CaptchaByteData = result.CaptchaByteData;
            Timestamp = result.Timestamp;
        }

        public bool Failed { get; set; } = false;

        public string CaptchaCode { get; set; }

        public byte[] CaptchaByteData { get; set; }

        public string CaptchaBase64Data => CaptchaByteData == null ? string.Empty : Convert.ToBase64String(CaptchaByteData);

        public DateTime Timestamp { get; set; }
    }
}
