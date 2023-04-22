using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class LocalizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
