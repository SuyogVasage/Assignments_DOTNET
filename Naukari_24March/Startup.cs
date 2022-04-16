using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Naukari_24March.Models;
using Microsoft.EntityFrameworkCore;
using Naukari_24March.Services;
using Naukari_24March.Data;
using Microsoft.AspNetCore.Identity;

namespace Naukari_24March
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<NaukariContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppConnSt"));
            });

            services.AddDbContext<Naukari_24MarchContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("Naukari_24MarchContextConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<Naukari_24MarchContext>();

            services.AddScoped<IService<PersonalInfo, int>, PersonalInfoService>();
            services.AddScoped<IService<EducationInfo, int>, EducationalInfoService>();
            services.AddScoped<IService<ProfessionalInfo, int>, ProfessionalInfoservice>();
            services.AddScoped<IService<EmployerInfo, int>, EmployerInfoService>();  

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Naukari_24MarchContext>()
             .AddDefaultUI();

            services.AddAuthorization();


            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
