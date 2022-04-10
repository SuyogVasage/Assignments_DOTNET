using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CS_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using CS_WebApp.Services;
using System;
using CS_WebApp.CustomFilters;
using Microsoft.AspNetCore.Identity;
using CS_WebApp.Data;

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

            //Addition for Identity from IdentityHostingStartup.cs class
            //
            services.AddDbContext<CS_WebAppContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("CS_WebAppContextConnection")));
            //Register identity provider classes in Dependency Container
            //UserManager<IdentityUser> : User management (CRUD)
            //SignInManger<IsentityUser> : User Login Management
            services.AddDefaultIdentity<IdentityUser>()
            //(options => 
            //Navigate to the confirm Email page when new user is registerd
            //options.SignIn.RequireConfirmedAccount = true)
            //Connect to DB for security using EFCore
            .AddEntityFrameworkStores<CS_WebAppContext>();
            // .AddDefaultUI();

            //Register the custom services those contains Business logic
            //                  Service Interface, Class Implementing, Service Interface

            services.AddScoped<IService<Department, int>, DeptService>();
            services.AddScoped<IService<Employee, int>, EmpService>();
            services.AddScoped<IService<User, int>, UserService>();
            services.AddScoped<IService<RequestLog, int>, RequestLogsService>();
            services.AddScoped<IService<ExceptionLog, int>, ExceptionLogService>();

           
            // COnfigure the Memory Cache
            // THe Same memory where the Host is executing 
            // the Application
            services.AddMemoryCache();

            // COfigure Sessions
            // The Session Time out is 20 Mins for Idle Request
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });


           
           // services.AddControllersWithViews(options => {
                //options.Filters.Add(typeof(LogFilterAttribute));
                // Comment Becoz of Razor Views
                //options.Filters.Add(typeof(LogFilterAttribute));
                // REgister the Exception Filter
                // The IModelMetadataProvider will be resolved by the 
                // PIpeline
                // Comment Becoz of Razor Views
                //options.Filters.Add(typeof(AppExceptionFilterAttribute));

           // });
            //Add service to support an wxecution of Razpor Pages for Identity
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

            //genrate Route table
            app.UseRouting();

            app.UseSession();

            //Middleware for User Authentication
            app.UseAuthentication();

            app.UseAuthorization();

            //Map with Incoming Request with the controller (MVC and API)
            //Map the Incoming Request with Razor Views
            app.UseEndpoints(endpoints =>
            {
                //Map with MVC Controller
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //Map Request to Razor View for Identity Pages
            endpoints.MapRazorPages();
            });
        }
    }
}
