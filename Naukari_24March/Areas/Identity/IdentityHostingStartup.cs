using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Naukari_24March.Data;

[assembly: HostingStartup(typeof(Naukari_24March.Areas.Identity.IdentityHostingStartup))]
namespace Naukari_24March.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<Naukari_24MarchContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("Naukari_24MarchContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<Naukari_24MarchContext>();
            });
        }
    }
}
