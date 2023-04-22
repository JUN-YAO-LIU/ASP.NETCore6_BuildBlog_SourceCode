using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class MultiController : Controller
    {
        private readonly ILogger<MultiController> _logger;

        public MultiController(ILogger<MultiController> logger)
        {
            _logger = logger;
        }

        public IActionResult Article()
        {
            return Content("Article !!");
        }
    }
}