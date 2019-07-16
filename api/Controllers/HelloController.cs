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
            return new JsonResult("hello");
        }
    }
}