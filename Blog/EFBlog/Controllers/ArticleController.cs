using EFBlog.Applications.ArticleService;
using EFBlog.ViewModels.ArticleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EFBlog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _article;

        public ArticleController(IArticleService articleService)
        {
            _article = articleService;
        }

        [HttpGet("Article/{id}")]
        public async Task<IActionResult> Index(long id)
        {
            var model = await _article.GetArticle(id);

            if (model is not null)
            {
                return View(model);
            }

            return Redirect("/");
        }

        [Authorize]
        [HttpGet("CreateArticle")]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [Authorize]
        [HttpPost("CreateArticle")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(UpdateArticleViewModel model)
        {
            await _article.CreateArticle(model);
            return Redirect("/");
        }

        [HttpGet("GetArticleList")]
        public async Task<IActionResult> GetArticleList()
        {
            var model = await _article.GetUpdateArticleList();
            return View(model);
        }

        [HttpGet("UpdateArticle/{id}")]
        public async Task<IActionResult> UpdateArticle(long id)
        {
            var model = await _article.GetUpdateArticle(id);
            if (model is not null)
            {
                return View(model);
            }

            return Redirect("/");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostUpdateArticle(UpdateArticleViewModel model)
        {
            await _article.UpdateArticle(model);
            return RedirectToAction($"GetArticleList");
        }

        [HttpGet("GetDeleteArticleList")]
        public async Task<IActionResult> GetDeleteArticleList()
        {
            var model = await _article.GetUpdateArticleList();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteArticle(long id)
        {
            await _article.DeleteArticle(id);
            return RedirectToAction($"GetArticleList");
        }

        [Authorize]
        public async Task<IActionResult> Uploads(IFormFile upload)
        {
            var obj = await _article.UploadImage(upload);

            return Json(new
            {
                uploaded = obj.Uploaded,
                fileName = obj.FileName,
                url = obj.Url,
                error = new
                {
                    message = obj.Msg
                }
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetMoreArticle()
        {
            var nextArticleId = TempData["ArticleLastId"];

            if (TempData["ArticleLastId"] != null && int.TryParse(TempData["ArticleLastId"]!.ToString(), out var i))
            {
                var model = await _article.GetMoreArticleList(i);
                var result = new List<UpdateArticleViewModel>();

                if (model is not null && model.Count > 0)
                {
                    result = model.Select(x => new UpdateArticleViewModel
                    {
                        Id = x.Id,
                        ArticleContent = x.ArticleContent,
                        Title = x.Title,
                        IsDelete = x.IsDelete
                    }).ToList();

                    TempData["ArticleLastId"] = result.Last().Id.ToString();
                }

                return Json(result);
            }

            return Json(string.Empty);
        }
    }
}