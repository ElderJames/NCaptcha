using Microsoft.AspNetCore.Hosting;
using NCaptcha.Samples.AspNetCore.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace NCaptcha.Samples.AspNetCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}