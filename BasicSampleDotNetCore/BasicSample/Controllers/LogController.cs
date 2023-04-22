using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("About page visited at {0}",
                "嗨");

            _logger.LogDebug(10, "Test  LogDebug");
            _logger.LogInformation(11, "Test LogInformation");
            _logger.LogWarning(12, "Test LogWarning");
            _logger.LogError(13, "Test LogError");
            _logger.LogCritical("Test LogCritical");

            return Redirect("/");
        }
    }
}