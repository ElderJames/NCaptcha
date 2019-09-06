using System.Threading.Tasks;

namespace NCaptcha.Targets.Email.Abstractions
{
    public interface IEmailSender
    {
        Task SendAsync(string emailTo, string subject, string body);
    }
}
