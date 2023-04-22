namespace EFBlog.Models
{
    // 程式碼編號：Models.Article
    public class Article
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ArticleContent { get; set; } = string.Empty;

        public bool IsDelete { get; set; }
    }
}