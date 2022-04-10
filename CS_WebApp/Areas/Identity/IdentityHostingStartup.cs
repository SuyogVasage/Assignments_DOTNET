using System;
using CS_WebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CS_WebApp.Areas.Identity.IdentityHostingStartup))]
namespace CS_WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<CS_WebAppContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("CS_WebAppContextConnection")));

            //    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<CS_WebAppContext>();
            //});
        }
    }
}
