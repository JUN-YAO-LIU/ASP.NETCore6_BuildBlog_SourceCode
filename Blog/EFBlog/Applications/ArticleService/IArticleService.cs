using EFBlog.Models;
using EFBlog.ViewModels.ArticleService;
using Microsoft.AspNetCore.Mvc;

namespace EFBlog.Applications.ArticleService
{
    public interface IArticleService
    {
        Task<ImageUploadResponse> UploadImage(IFormFile upload);

        Task CreateArticle(UpdateArticleViewModel model);

        Task UpdateArticle(UpdateArticleViewModel model);

        Task<IList<ArticleViewModel>> GetListArticle();

        Task<IList<Article>> GetMoreArticleList(long id);

        Task<ArticleViewModel> GetArticle(long id);

        Task<IList<UpdateArticleViewModel>> GetUpdateArticleList();

        Task<UpdateArticleViewModel> GetUpdateArticle(long id);

        Task DeleteArticle(long id);
    }
}