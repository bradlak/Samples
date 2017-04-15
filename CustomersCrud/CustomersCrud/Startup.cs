using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CustomersCrud.Data;
using CustomersCrud.Logging;
using AutoMapper;
using CustomersCrud.Interfaces;
using CustomersCrud.Services;

namespace CustomersCrud
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomersContext>(
                     opt => opt.UseSqlServer(Configuration.GetConnectionString("Database")));

            services.AddLogging();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<ICustomersRepository, CustomersRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var loggingSettings = new LoggingSettings();
            Configuration.GetSection("ApplicationInsights").Bind(loggingSettings);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddApplicationInsightsLogger(loggingSettings);
            app.UseMvc();
        }
    }
}
