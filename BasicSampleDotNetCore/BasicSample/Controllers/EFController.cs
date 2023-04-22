using BasicSample.DbAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace BasicSample.Controllers
{
    public class EFController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EFController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Index()
        {
            // ----- 取得第一筆資料 -----

            // 同步
            var first = _db.Users
                    .First();

            // 非同步
            var firstAsync = await _db.Users
                .FirstAsync();

            // ----- 取得第一筆資料，沒資料回傳Null -----

            // 同步
            var firstorDefault = _db.Users
                .FirstOrDefault();

            // 非同步
            var firstorDefaultAsync = await _db.Users
                .FirstOrDefaultAsync();

            // ----- 取得多筆資料 -----

            // 同步
            var list = _db.Users
                   .ToList();

            // 非同步
            var listAsync = await _db.Users
                .ToListAsync();

            // ----- 條件查詢 -----
            var whereList = _db.Users
                .Where(x => x.Name.Length > 2)
                .ToList();

            // ----- 依照特定欄位排序(由小到大排) -----
            var orderByList = _db.Users
                .OrderBy(x => x.Name)
                .ToList();

            // -----依照特定欄位排序(由大到小排)-----
            var orderByDescList = _db.Users
                .OrderByDescending(x => x.Name)
                .ToList();

            // ----- 翻轉資料順序 -----
            var reverseList = _db.Users
                .OrderBy(x => x.Name)
                .Reverse()
                .ToList();

            // ----- Left Join -----
            var leftjoin = await _db.Users.GroupJoin(
                _db.Orders,
                x => x.Id,
                y => y.UserId,
                (x, y) => new
                {
                    user = x,
                    order = y
                })
                .SelectMany(x => x.order.DefaultIfEmpty(), (x, y) =>
                new
                {
                    userId = x.user.Id,
                    userName = x.user.Name,
                    product = y.Product,
                })
                .ToListAsync();
        }

        public async Task Txn()
        {
            using var txn = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var user = _db.Users.Add(new DbAccess.Models.User
            {
                Name = "Jim01"
            });
            await _db.SaveChangesAsync();

            _db.Orders.Add(new DbAccess.Models.Order
            {
                UserId = user.Entity.Id,
                Product = "JimProduct01"
            });

            await _db.SaveChangesAsync();
            txn.Complete();
        }
    }
}