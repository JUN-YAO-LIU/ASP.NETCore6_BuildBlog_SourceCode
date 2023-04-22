using BasicSample.DbAccess.Models;
using BasicSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasicSample.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        // 明確檢視
        public IActionResult AboutTest()
        {
            return View("About_Test");
        }

        // 強型別 - viewModel
        public IActionResult SendModel()
        {
            return View(new Car { Name = "Test", Description = "描述" });
        }

        // 明確檢視
        public IActionResult SendModelToSpecialView()
        {
            return View("SpecialViewGetModel", new Car { Name = "Test", Description = "描述" });
        }

        // 弱型別 - ViewBag
        public IActionResult TestViewBag()
        {
            ViewBag.Title = "Title";
            return View();
        }

        // 弱型別 - ViewData
        public IActionResult TestViewData()
        {
            ViewData["Title"] = "Test";
            return View();
        }

        // 弱型別 - ViewData屬性應用

        [ViewData]
        public string TestViewDataProperty_Title { get; set; } = string.Empty;

        public IActionResult TestViewDataProperty()
        {
            TestViewDataProperty_Title = "ViewData 屬性用法";
            return View();
        }

        // 弱型別 - Tempdate
        public IActionResult TestTempDateLocalView()
        {
            TempData["TempTitle"] = "TempData不跳轉頁面測試";
            return View();
        }

        public IActionResult TestTempDate()
        {
            TempData["TestTemp"] = "測試";
            ViewBag.Test = "ViewBag Test";

            return LocalRedirect("~/Home/Test_TempDataViewBag");
        }

        public IActionResult TestPartial()
        {
            return View(new Car
            {
                Name = "Partial Car",
                Description = "部分檢視 車車"
            });
        }

        public IActionResult TestViewInject()
        {
            return View();
        }
    }
}