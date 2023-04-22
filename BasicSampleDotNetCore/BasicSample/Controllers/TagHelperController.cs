using BasicSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicSample.Controllers
{
    public class TagHelperController : Controller
    {
        public IActionResult Index(TestBasicTaghelper model)
        {
            return View();
        }

        public void TestRouteId(int id)
        {
        }

        public void TestRoute(string name, string age)
        {
        }

        public IActionResult UploadFiles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(UploadData model)
        {
            if (model.File is not null)
            {
                var file = model.File;
                string uploadFilePath = $"{Directory.GetCurrentDirectory()}/wwwroot/{file.FileName}";

                using var stream = System.IO.File.Create(uploadFilePath);
                await file.CopyToAsync(stream);
            }
            return View("UploadFiles");
        }
    }
}