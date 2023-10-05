using Microsoft.EntityFrameworkCore;
using System;
using TestLEAE.BusinessLayer;
using TestLEAE.DataLayer;

namespace TestLEAE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            //services.AddControllers();
            services.AddControllersWithViews();
            services.AddDbContext<SqlReportingContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IClientOperationsService, ClientOperationsService>();
            services.AddScoped<IFounderOperationsService, FounderOperationsService>();
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env) 
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
