using System.Threading.Tasks;

namespace NCaptcha.Targets.Sms.Abstractions
{
    public interface ISmsReceiverSelector
    {
        Task<string> SelectAsync();
    }
}
