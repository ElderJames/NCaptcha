using System.Threading.Tasks;

namespace NCaptcha.Targets.Sms.Abstractions
{
    public interface ISmsSender
    {
        Task SendAsync(string phoneNumber, string content);
    }
}
