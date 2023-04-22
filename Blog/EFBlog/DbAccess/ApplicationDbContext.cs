using EFBlog.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace EFBlog.DbAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<AuthUser> AuthUsers { get; set; }

        protected override void OnModelCreating(
        ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 為每個 Table 詳細定義內容
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}