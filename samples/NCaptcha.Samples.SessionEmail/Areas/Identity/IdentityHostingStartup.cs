using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCaptcha.Samples.SessionEmail.Data;

[assembly: HostingStartup(typeof(NCaptcha.Samples.SessionEmail.Areas.Identity.IdentityHostingStartup))]
namespace NCaptcha.Samples.SessionEmail.Areas.Identity
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