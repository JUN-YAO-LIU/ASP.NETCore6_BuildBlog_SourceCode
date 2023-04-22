using EFBlog.Applications.ArticleService;
using EFBlog.ViewModels;
using EFBlog.ViewModels.ArticleService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _article;

        public HomeController(ILogger<HomeController> logger, IArticleService article)
        {
            _logger = logger;
            _article = article;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var model = await _article.GetListArticle();
            var result = new List<ArticleViewModel>();

            if (model is not null && model.Count > 0)
            {
                result = model.Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    ArticleContent = x.ArticleContent,
                    Title = x.Title
                }).ToList();

                TempData["ArticleLastId"] = result.Last().Id.ToString();
            }

            return View(result);
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