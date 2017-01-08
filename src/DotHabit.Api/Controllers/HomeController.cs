using System;
using Microsoft.AspNetCore.Mvc;

namespace DotQuiz.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller 
    {
        [Route("")]
        public IActionResult Index() 
        {
            return Ok(new {
                now = DateTime.UtcNow
            });
        }
    }
}