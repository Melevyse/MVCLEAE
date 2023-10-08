using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
            services.AddDbContext<SqlReportingContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IClientOperationsService, ClientOperationsService>();
            services.AddScoped<IFounderOperationsService, FounderOperationsService>();
            services.AddScoped<IClientOperationsRepository, ClientOperationsRepository>();
            services.AddScoped<IFounderOperationsRepository, FounderOperationsRepository>();

            services.AddTransient<IValidationPrimitivesService, ValidationPrimitivesService>();
            services.AddTransient<IValidator<Client>, ClientItemValidator>();
            services.AddTransient<IValidator<Founder>, FounderItemValidator>();

            services.AddValidatorsFromAssemblyContaining<Startup>();

            services.AddLogging((builder => builder.AddConsole()));
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILogger<Startup> logger) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
