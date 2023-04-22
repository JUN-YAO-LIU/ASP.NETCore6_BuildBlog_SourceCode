using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BasicSample.Controllers
{
    public class EnvironmentController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public EnvironmentController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Dev()
        {
            if (_env.IsDevelopment())
            {
                ViewBag.EnvName = _env.EnvironmentName;
            }

            return View();
        }

        public IActionResult Prod()
        {
            return View();
        }
    }
}