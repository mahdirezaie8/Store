using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Core.Entities;
using Store.Domain.Core.Enums;
namespace Store.Infra.Db.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(250);
            builder.HasOne(u => u.IdentityUser).WithOne().HasForeignKey<User>(u => u.IdentityUserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new User { Id = 1, FullName = "مهدی رضایی", Wallet = 1000000000, IsActive = true, IdentityUserId = 1 });
            builder.HasData(new User { Id = 2, FullName = "فاطمه محمدی", Wallet = 500000000, IsActive = true, IdentityUserId = 2 });
            builder.HasData(new User { Id = 3, FullName = "حسن نوری", Wallet = 200000000, IsActive = true, IdentityUserId = 3 });
        }
    }
}
