using System;
using FitHub.Contexts;
using FitHub.Data;
using FitHub.Data.Repositories;
using FitHub.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FitHub
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment, IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment _environment;

        private ILogger<Startup> _logger;


        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddMvc();

            if (_environment.IsDevelopment())
            {
                // Configuring the DbContext used for the Identity database.
                services.AddDbContext<CustomIdentityContext>(options =>
                {
                    options.UseSqlServer(Environment.GetEnvironmentVariable("IdentityConnectionString"),
                        optionsBuilder => optionsBuilder.MigrationsAssembly("FitHub"));
                });
            }
            else if (_environment.IsProduction())
            {
                // Configuring the DbContext used for the Identity database.
                services.AddDbContext<CustomIdentityContext>(options =>
                {
                    options.UseSqlServer(Environment.GetEnvironmentVariable("ProdIdentityConnectionString"),
                        optionsBuilder => optionsBuilder.MigrationsAssembly("FitHub"));
                });
            }

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityContext>()
                .AddDefaultTokenProviders();

            //services.AddTransient<IMessageService, FileMessageService>();
            services.AddTransient<IMessageService, SendGridMessageService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
