using EFBlog.Applications.Auth;
using EFBlog.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EFBlog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _auth;

        public LoginController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //while (true)
            //{
            //    Thread.Sleep(5000);

            //    // 資料庫讀取參數
            //    int a = 1;

            //    // 判斷參數
            //    if (a == 1)
            //    {
            //        return Redirect("TestJump");
            //    }
            //    else
            //    {
            //        return View();
            //    }

            //    a++;
            //}

            return View();
        }

        [HttpGet("TestJump")]
        public IActionResult TestJump()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest model)
        {
            if (await _auth.LoginUserCheckPwd(model))
            {
                var claims = new List<Claim>
                {
                    new Claim("UserCode",model.Pwd),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),
                        IsPersistent = true,
                    });

                return Redirect("/");
            }

            return View();
        }
    }
}