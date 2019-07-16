using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [Route("")]
        public IActionResult Index(string name = "")
        {
            var greeting = "hello";
            if (!string.IsNullOrWhiteSpace(name))
            {
                greeting += $" {name}";
            }
            return new JsonResult(greeting);
        }
    }
}