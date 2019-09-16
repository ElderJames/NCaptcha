using System.Threading.Tasks;
using NCaptcha.Targets.Sms.Abstractions;

namespace NCaptcha.Targets.Sms.Aliyun
{
    public class AliyunSmsSender : ISmsSender
    {
        private readonly AliyunSmsSdk _sdk;

        public AliyunSmsSender(AliyunSmsSdk sdk)
        {
            _sdk = sdk;
        }

        public Task SendAsync(string phoneNumber, string content)
        {
            return _sdk.SendVerificationCodeAsync(phoneNumber, content);
        }
    }
}
