using Swashbuckle.AspNetCore.Swagger;

namespace DotQuiz.Api.Configuration.Swagger
{
    public class SwaggerConfiguration
    {
        public Info[] ApplicationInfo { get; set; }

        public bool IsEnabled { get; set; }
    }
}