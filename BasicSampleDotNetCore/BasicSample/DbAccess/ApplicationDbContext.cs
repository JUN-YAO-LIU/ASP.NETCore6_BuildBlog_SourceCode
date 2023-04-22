using BasicSample.DbAccess.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace BasicSample.DbAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
    }
}