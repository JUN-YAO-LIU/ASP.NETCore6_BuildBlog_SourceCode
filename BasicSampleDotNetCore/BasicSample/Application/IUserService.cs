using BasicSample.DbAccess.Models;

namespace BasicSample.Application
{
    public interface IUserService
    {
        IList<User> GetUserList();

        void CreateUser(string name);

        void UpdateUser(string from, string to);

        void DeleteUser(string name);
    }
}