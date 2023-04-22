using BasicSample.DbAccess;
using BasicSample.DbAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicSample.Application
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<User> GetUserList()
        {
            var result = _db.Users.ToList();
            return result;
        }

        public void CreateUser(string name)
        {
            _db.Users.Add(
                new User
                {
                    Name = name
                });
            _db.SaveChanges();
        }

        public void UpdateUser(string from, string to)
        {
            var user = _db.Users.Where(x => x.Name == from).FirstOrDefault();

            if (user is not null)
            {
                user.Name = to;
                _db.Users.Update(user);
                _db.SaveChanges();
            }
        }

        public void DeleteUser(string name)
        {
            var user = _db.Users.Where(x => x.Name == name).FirstOrDefault();

            if (user is null)
            {
                throw new Exception("User Not Found !!");
            }

            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}