using System;

namespace NCaptcha.Abstractions
{
    public class FileCaptchaResult : CaptchaResult
    {
        public byte[] CaptchaByteData
        {
            get { return base["CaptchaByteData"] as byte[]; }
            set { base["CaptchaByteData"] = value; }
        }

        public string CaptchaBase64Data => CaptchaByteData == null ? string.Empty : Convert.ToBase64String(CaptchaByteData);
    }
}
