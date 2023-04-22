using EFBlog.DbAccess;
using EFBlog.Models;
using EFBlog.ViewModels.ArticleService;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Imaging;

namespace EFBlog.Applications.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _db;

        public ArticleService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateArticle(UpdateArticleViewModel model)
        {
            var article = new Article
            {
                Title = model.Title,
                ArticleContent = model.ArticleContent,
                IsDelete = model.IsDelete
            };

            _db.Articles.Add(article);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateArticle(UpdateArticleViewModel model)
        {
            var data = await _db.Articles
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new Exception("search error");
            }

            data.Title = model.Title;
            data.ArticleContent = model.ArticleContent;
            data.IsDelete = model.IsDelete;

            _db.Articles.Update(data);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<ArticleViewModel>> GetListArticle()
        {
            return await _db.Articles
                .Where(x => x.IsDelete == false)
                .Take(2)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    ArticleContent = x.ArticleContent,
                    Title = x.Title
                })
                .ToListAsync();
        }

        public async Task<ArticleViewModel> GetArticle(long id)
        {
            var result = await _db.Articles
                .Where(x => x.IsDelete == false && x.Id == id)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    ArticleContent = x.ArticleContent,
                    Title = x.Title
                })
                .FirstOrDefaultAsync();

            return result ?? new();
        }

        public async Task<IList<UpdateArticleViewModel>> GetUpdateArticleList()
        {
            return await _db.Articles
                .Select(x => new UpdateArticleViewModel
                {
                    Id = x.Id,
                    IsDelete = x.IsDelete,
                    Title = x.Title,
                    ArticleContent = x.ArticleContent
                })
                .ToListAsync();
        }

        public async Task<UpdateArticleViewModel> GetUpdateArticle(long id)
        {
            var data = await _db.Articles
                  .Where(x => x.Id == id)
                  .Select(x => new UpdateArticleViewModel
                  {
                      Id = x.Id,
                      IsDelete = x.IsDelete,
                      Title = x.Title,
                      ArticleContent = x.ArticleContent
                  })
                  .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new Exception("search error");
            }

            return data;
        }

        public async Task<ImageUploadResponse> UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null!;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var filePath = Path.Combine(
                   Directory.GetCurrentDirectory(), "wwwroot/images",
                   fileName);

            using (var stream = File.Create(filePath))
            {
                //程式寫入的本地資料夾裡面
                await upload.CopyToAsync(stream);
            }

            var url = $"{"/images/"}{fileName}";

            var reslult = new ImageUploadResponse
            {
                Uploaded = 1,
                FileName = fileName,
                Url = url,
                Msg = "sucess",
            };

            return reslult;
        }

        public async Task<IList<Article>> GetMoreArticleList(long id)
        {
            return await _db.Articles
                 .Where(x => x.Id > id)
                 .Select(x => new Article
                 {
                     Id = x.Id,
                     Title = x.Title,
                     // ArticleContent = RemoveHtmlTags(x.ArticleContent, 100),
                     // IsVIPArticle = x.IsVIPArticle,
                     IsDelete = x.IsDelete,
                 })
                .ToListAsync();
        }

        public async Task DeleteArticle(long id)
        {
            var rm = await _db.Articles.Where(x => x.Id == id)
                   .FirstOrDefaultAsync();

            if (rm is not null)
            {
                _db.Remove(rm);
                await _db.SaveChangesAsync();
            }
        }

        private void GetInsertContentImages(string content)
        {
            var strList = content.Split("images/").ToList();
            IList<Guid> imageList = new List<Guid>();

            foreach (var str in strList)
            {
                if (str.Length < 36)
                {
                    continue;
                }

                var tempGuid = str.Substring(0, 36);
                if (Guid.TryParse(tempGuid, out Guid r))
                {
                    imageList.Add(r);
                }
            }
        }
    }
}