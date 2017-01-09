using System;
using Microsoft.AspNetCore.Mvc;

namespace DotQuiz.Api.Controllers
{
    [Route("api")]
    public class HomeController : Controller 
    {
        [Route("values")]
        public IActionResult Index() 
        {
            return Ok(new {
                now = DateTime.UtcNow,
                values = new[] {
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }
            });
        }
    }
}