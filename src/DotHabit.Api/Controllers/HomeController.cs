using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DotQuiz.Api.Controllers
{
    [Route("api")]
    public class HomeController : Controller 
    {
        private IHostingEnvironment env;
        public HomeController(IHostingEnvironment env)
        {
            this.env = env;
        }

        [Route("values")]
        public IActionResult Index() 
        {
            return Ok(new {
                now = DateTime.UtcNow,
                env = env.EnvironmentName,
                values = new[] {
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }
            });
        }
    }
}