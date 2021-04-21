using System;
using Drop.Web.Areas.Identity.Data;
using Drop.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Drop.Web.Areas.Identity.IdentityHostingStartup))]
namespace Drop.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DropWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DropWebContextConnection")));

                services.AddDefaultIdentity<DropWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DropWebContext>();
            });
        }
    }
}