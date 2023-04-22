using BasicSample.DbAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;

namespace BasicSample.Controllers
{
    public class SecurityController : Controller
    {
        private readonly HtmlEncoder _htmlEncoder;
        private readonly JavaScriptEncoder _javaScriptEncoder;
        private readonly UrlEncoder _urlEncoder;

        private readonly ApplicationDbContext _db;

        public SecurityController(
            HtmlEncoder htmlEncoder,
            JavaScriptEncoder javaScriptEncoder,
            UrlEncoder urlEncoder,
            ApplicationDbContext db)
        {
            _htmlEncoder = htmlEncoder;
            _javaScriptEncoder = javaScriptEncoder;
            _urlEncoder = urlEncoder;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Validation()
        {
            return View();
        }

        public IActionResult Cors()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CSRF()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CSRF(string name)
        {
            return View();
        }

        [HttpGet]
        public IActionResult XSS()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XSS(string content)
        {
            var htmlContnet = _htmlEncoder.Encode(content);
            var jsContnet = _javaScriptEncoder.Encode(content);
            var urlContnet = _urlEncoder.Encode(content);

            ViewBag.html = htmlContnet;
            ViewBag.dontEncodeHtml = content;
            ViewBag.js = jsContnet;
            ViewBag.url = urlContnet;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SQLInjection(string? search)
        {
            if (string.IsNullOrEmpty(search))
            {
                ViewBag.Result = "請輸入查詢條件";
                return View();
            }

            // 攻擊字串'; drop table users;--
            string sqlString = $"select * from [Users] where (1=1) AND name = '{search}' ";

            var data = await _db.Users
                .FromSqlRaw(sqlString)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();

            ViewBag.Result = data ?? "查無資料";

            //var sqlParameter = new SqlParameter("@name", search);
            //string sqlString2 = $"select * from [Users] where (1=1) AND name = @name";

            //var data2 = await _db.Users
            //    .FromSqlRaw(sqlString2, sqlParameter)
            //    .Select(x => x.Name)
            //    .FirstOrDefaultAsync();

            //ViewBag.Result = data2 ?? "查無資料";
            return View();
        }
    }
}