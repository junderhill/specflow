using System;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [Route("api/calculator/add")]
        public IActionResult Add(int first, int second){
            var sum = first + second;
            return new JsonResult(sum.ToString());
        }
    }
}