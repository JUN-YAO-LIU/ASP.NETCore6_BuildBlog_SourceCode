using EFBlog.DbAccess;
using EFBlog.ViewModels.Auth;
using Microsoft.EntityFrameworkCore;

namespace EFBlog.Applications.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;

        public AuthService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> LoginUserCheckPwd(LoginRequest model)
        {
            return await _db.AuthUsers.AnyAsync(x => x.Pwd == model.Pwd);
        }
    }
}