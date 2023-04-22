namespace EFBlog.ViewModels.ArticleService
{
    public class ImageUploadResponse
    {
        public int Uploaded { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Msg { get; set; } = string.Empty;
    }
}