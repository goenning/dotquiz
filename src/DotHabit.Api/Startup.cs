using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DotQuiz.Api.Configuration.Swagger;
using Serilog;

namespace DotQuiz.Api
{
    public class Startup 
    {
        private IConfigurationRoot configuration;
        private SwaggerConfiguration swaggerConfig = new SwaggerConfiguration();
        private IHostingEnvironment env;

        public Startup(IHostingEnvironment env)
        {
            this.env = env;
            this.configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config/appsettings.json")
                .AddJsonFile($"config/appsettings.{env.EnvironmentName}.json", true)
                .Build();
                
            this.configuration.GetSection("Swagger").Bind(this.swaggerConfig);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(this.configuration)
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddMvc();
            services.AddCustomSwagger(this.swaggerConfig);
        }

        public void Configure(IApplicationBuilder app, 
                              ILoggerFactory logger,
                              IApplicationLifetime appLifetime)
        {
            app.UseCustomSwagger(this.swaggerConfig);
            app.UseMvc();
            
            logger.AddSerilog();
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
        }
    }
}