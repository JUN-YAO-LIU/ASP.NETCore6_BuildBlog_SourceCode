using BasicSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BasicSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Car(int id)
        {
            string[] cars = { "Porsche", "Ferrari", "Lamborghini" };
            return Content(cars[id % cars.Length]);
        }

        public IActionResult Test_LocalRedirect_Destination()
        {
            return Content("LocalRedirect_Destination !!，這裡是HomeController");
        }

        [NonAction]
        public void RemoveAction()
        {
        }

        public IActionResult Test_TempDataViewBag()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}