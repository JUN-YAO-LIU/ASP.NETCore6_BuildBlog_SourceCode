using BasicSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class RazorController : Controller
    {
        public IActionResult Razor()
        {
            return View();
        }

        public IActionResult BasicSyntax()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FourMethodControllerSendValueToView()
        {
            ViewData["Num"] = 12;
            ViewData["ViewName"] = "Jack";
            ViewData["ViewDate"] = DateTime.UtcNow;

            ViewBag.BagNum = 13;
            ViewBag.BagName = "Bag名稱";
            ViewBag.Bag日期 = DateTime.UtcNow;

            TempData["TempDate"] = DateTime.UtcNow;
            TempData["TempNum"] = 1;
            TempData["TempName"] = "名稱";

            var Model = new TestTagHelper
            {
                BirthDay = DateTime.UtcNow,
                Amount = 32,
                Email = "test@gmail.com"
            };

            return View(Model);
        }

        [HttpGet]
        public IActionResult HtmlHelper()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TestHtmlHelper()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TestDataTypeHtmlHelper()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TestDataTypeHtmlHelper(TestDataTypeHtmlHelper obj)
        {
            if (ModelState.IsValid)
            {
                return View(obj);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HtmlHelper(TestTagHelper obj)
        {
            // 會吃物件的設定，如果允許null 請給問號
            // 沒有問號就是Require
            if (ModelState.IsValid)
            {
                return View(obj);
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult TagHelper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TagHelper(TestTagHelper obj)
        {
            return View();
        }


        [HttpGet]
        public IActionResult RemoveTagHelper()
        {
            return View();
        }
    }
}