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
using CS_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using CS_WebApp.Services;
namespace CS_WebApp
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
            //Register The DAL DBContext
            //By passing the Connection string info
            //By reading jey from the appsettings.json

            services.AddDbContext<IndustryContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppConnSt"));
            });

            //Register the custom services those contains Business logic
            //                  Service Interface, Class Implementing, Service Interface

            services.AddScoped<IService<Department, int>, DeptService>();
            services.AddScoped<IService<Employee, int>, EmpService>();
            services.AddScoped<IService<User, int>, UserService>();


            services.AddControllersWithViews();
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

            app.UseAuthorization();

            //Map with Incoming Request with the controller (MVC and API)
            //Map the Incoming Request with Razor Views
            app.UseEndpoints(endpoints =>
            {
                //Map with MVC Controller
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
