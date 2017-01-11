using System.Collections.Generic;
using DotQuiz.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotQuiz.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class LocaleController : Controller 
    {
        private IHostingEnvironment env;
        private ILogger logger;
        public LocaleController(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            this.env = env;
            this.logger = loggerFactory.CreateLogger(typeof(LocaleController));
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<Locale>))]
        [ProducesResponseType(typeof(IEnumerable<Locale>), 200)]
        public IActionResult Get() 
        {
            logger.LogDebug($"Get locales started...");
            var locales = new[] {
                new Locale("pt", "BR"),
                new Locale("en", "US"),
                new Locale("en", "GB"),
            };
            logger.LogDebug("Locales are {@locale} on {@env} environment", locales, env.EnvironmentName);

            return Ok(locales);
        }
    }
}