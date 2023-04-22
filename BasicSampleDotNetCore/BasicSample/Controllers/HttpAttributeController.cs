using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class HttpAttributeController : Controller
    {
        private readonly ILogger<HttpAttributeController> _logger;

        public HttpAttributeController(ILogger<HttpAttributeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("~/http-attribute")]
        public IActionResult Fun1()
        {
            return Content("Http Attribute Fun1");
        }

        [HttpPost("~/http-attribute")]
        public IActionResult Fun1([FromBody] int model)
        {
            return Content("Http Attribute Fun2 + " + model!.ToString()!);
        }
    }
}