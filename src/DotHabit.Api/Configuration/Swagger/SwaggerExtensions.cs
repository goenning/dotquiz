using DotQuiz.Api.Configuration.Swagger;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddCustomSwagger(
            this IServiceCollection services,
            SwaggerConfiguration configuration)
        {
            if (!configuration.IsEnabled) return services;

            services.AddSwaggerGen(c =>
            {
                foreach(var info in configuration.ApplicationInfo)
                {
                    c.SwaggerDoc(info.Version, info);
                }
            });

            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(
            this IApplicationBuilder app,
            SwaggerConfiguration configuration)
        {
            if (!configuration.IsEnabled) return app;

            app.UseSwagger();
            app.UseSwaggerUi(c =>
            {
                foreach(var info in configuration.ApplicationInfo)
                {
                    c.SwaggerEndpoint($"/swagger/{info.Version}/swagger.json", info.Title);
                }
            });

            return app;
        }
    }
}