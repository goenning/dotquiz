using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace DotQuiz.Api
{
    public class Startup 
    {
        public Startup()
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.LiterateConsole()
               .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "dotQuiz API v1", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              ILoggerFactory logger,
                              IApplicationLifetime appLifetime)
        {
            logger.AddSerilog();
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
            
            app.UseSwagger();
            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotQuiz API v1");
            });
            app.UseMvc();
        }
    }
}