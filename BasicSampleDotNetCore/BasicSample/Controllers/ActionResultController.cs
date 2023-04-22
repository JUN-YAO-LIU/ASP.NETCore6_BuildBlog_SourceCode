using BasicSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasicSample.Controllers
{
    public class ActionResultController : Controller
    {
        // 沒回傳-狀態碼
        public IActionResult Test_Ok()
        {
            return Ok();
        }

        public IActionResult Test_BadRequest()
        {
            return BadRequest();
        }

        public IActionResult Test_NotFound()
        {
            return NotFound();
        }

        public IActionResult Test_Unauthorized()
        {
            return Unauthorized();
        }

        public IActionResult Test_ReturnHttpStatusCode()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        public IActionResult Test_CustomerRequestStatus()
        {
            return StatusCode(999);
        }

        // 沒回傳-頁面跳轉
        public IActionResult Index()
        {
            return Content("歡迎一起測試 Action Result");
        }

        public IActionResult Test_Redirect()
        {
            return Redirect("https://www.google.com.tw/");
        }

        public IActionResult Test_LocalRedirect()
        {
            return LocalRedirect("~/Home/Test_LocalRedirect_Destination");
        }

        public IActionResult Test_RedirectToAction()
        {
            return RedirectToAction("Test_RedirectToAction_Destination");
        }

        public IActionResult Test_RedirectToAction_Destination()
        {
            return Content("RedirectToAction_Destination !!");
        }

        public IActionResult Test_RedirectToRoute()
        {
            return RedirectToRoute(new
            {
                controller = "ActionResult",
                action = "Test_RedirectToRoute_Destination",
                parameter1 = "Apple",
                parameter2 = "Orange"
            });
        }

        public IActionResult Test_RedirectToRoute_Destination(string parameter1, string parameter2)
        {
            return Content($"RedirectToRoute 傳來的參數，參數1：{parameter1}，參數2：{parameter2} !!");
        }

        // 有回傳
        public IActionResult Test_Content()
        {
            return Content("回傳測試訊息");
        }

        public IActionResult Test_View()
        {
            return View();
        }

        public IActionResult Test_Json()
        {
            return Json(new Car { Name = "Lamborghini", Description = "藍寶潔妮" });
        }

        public IActionResult Test_File()
        {
            return PhysicalFile($"{Directory.GetCurrentDirectory()}/wwwroot/File.txt", "APPLICATION/octet-stream", "TestFileName.txt");
        }
    }
}