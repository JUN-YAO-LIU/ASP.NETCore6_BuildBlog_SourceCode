using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class SpecialLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexV2()
        {
            return View();
        }

        public IActionResult RenderSectionView()
        {
            return View();
        }
    }
}