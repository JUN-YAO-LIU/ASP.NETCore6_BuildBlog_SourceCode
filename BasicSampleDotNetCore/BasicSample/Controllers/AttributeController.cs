using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class AttributeController : Controller
    {
        private readonly ILogger<AttributeController> _logger;

        public AttributeController(ILogger<AttributeController> logger)
        {
            _logger = logger;
        }

        [Route("Attribute")]
        [Route("Attribute/Index")]
        [Route("Attribute/Index/{id?}")]
        public IActionResult Fun1(int? id)
        {
            return Content("Fun1 + " + id.ToString()!);
        }

        [Route("Attribute/About")]
        [Route("Attribute/About/{id?}")]
        public IActionResult Fun2(int? id)
        {
            return Content("Fun2 + " + id!.ToString()!);
        }
    }
}