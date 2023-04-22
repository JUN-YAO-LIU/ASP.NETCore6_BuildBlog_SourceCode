using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class OptionController : Controller
    {
        public IActionResult TestOption()
        {
            return View();
        }
    }
}