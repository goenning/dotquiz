using DotQuiz.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DotQuiz.Api.Controllers
{
    [Route("api/v1/locales")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class LocaleController : Controller 
    {
        private IHostingEnvironment env;
        public LocaleController(IHostingEnvironment env)
        {
            this.env = env;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(new[] {
                new Locale("pt", "BR"),
                new Locale("en", "US"),
                new Locale("en", "GB"),
            });
        }
    }
}