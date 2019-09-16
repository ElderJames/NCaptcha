using System;
using System.Threading.Tasks;
using NCaptcha.Targets.Sms.Abstractions;

namespace NCaptcha.Targets.Sms
{
    public class ConsoleSmsSender : ISmsSender
    {
        public Task SendAsync(string phoneNumber, string content)
        {
            Console.WriteLine("================");
            Console.WriteLine($"sending sms to phone: {phoneNumber}");
            Console.WriteLine($"message is: {content}");
            Console.WriteLine("================");
            return Task.CompletedTask;
        }
    }
}
