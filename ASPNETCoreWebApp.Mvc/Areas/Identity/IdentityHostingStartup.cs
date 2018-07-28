using ASPNETCoreWebApp.Mvc.Areas.Identity.Data;
using ASPNETCoreWebApp.Mvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASPNETCoreWebApp.Mvc.Areas.Identity.IdentityHostingStartup))]

namespace ASPNETCoreWebApp.Mvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AspNetCoreIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<AspNetCoreIdentityUser>()
                    .AddEntityFrameworkStores<AspNetCoreIdentityContext>()
                    .AddDefaultTokenProviders();
            });
        }
    }
}