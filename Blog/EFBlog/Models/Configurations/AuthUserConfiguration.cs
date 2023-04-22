using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFBlog.Models.Configurations
{
    public class AuthUserConfiguration : IEntityTypeConfiguration<AuthUser>
    {
        public void Configure(EntityTypeBuilder<AuthUser> builder)
        {
            builder
                .Property(x => x.Account)
                .HasMaxLength(10)
                .HasColumnType("varchar")
                .HasComment("帳號")
                .IsRequired();

            builder
                .Property(x => x.Pwd)
                .HasMaxLength(10)
                .HasColumnType("varchar")
                .HasComment("密碼")
                .IsRequired();
        }
    }
}