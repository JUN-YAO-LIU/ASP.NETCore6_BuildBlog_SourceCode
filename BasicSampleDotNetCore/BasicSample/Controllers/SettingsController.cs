using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult GetINI()
        {
            return View();
        }

        public IActionResult GetJson()
        {
            return View();
        }

        public IActionResult GetXml()
        {
            return View();
        }
    }
}