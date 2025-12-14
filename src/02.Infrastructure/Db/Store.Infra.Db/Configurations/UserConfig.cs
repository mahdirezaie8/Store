using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Core.Entities;
using Store.Domain.Core.Enums;

namespace Store.Infra.Db.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.FullName).IsRequired().HasMaxLength(250);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(250);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(250);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(250);
            builder.HasData(new User { Id = 1, FullName = "مهدی رضایی", Username = "mahdirr", Password = "1234567", Email = "mahdi@gmail.com", Wallet = 1000000000,Role=(RoleEnum)0,IsActive=true });
            builder.HasData(new User { Id = 2, FullName = "فاطمه محمدی", Username = "fatemehm", Password = "1234567", Email = "fatemeh@gmail.com", Wallet = 500000000, Role = (RoleEnum)1, IsActive = true });
            builder.HasData(new User { Id = 3, FullName = "حسن نوری", Username = "hasannori", Password = "1234567", Email = "hasan@gmail.com", Wallet = 200000000, Role = (RoleEnum)1, IsActive = true });
        }
    }
}
