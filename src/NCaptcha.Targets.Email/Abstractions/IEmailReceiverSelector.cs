using System.Threading.Tasks;

namespace NCaptcha.Targets.Email.Abstractions
{
    public interface IEmailReceiverSelector
    {
        Task<string> SelectAsync();
    }
}
