using EFBlog.ViewModels.Auth;

namespace EFBlog.Applications.Auth
{
    public interface IAuthService
    {
        Task<bool> LoginUserCheckPwd(LoginRequest model);
    }
}