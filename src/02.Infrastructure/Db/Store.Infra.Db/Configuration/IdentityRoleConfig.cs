using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Infra.Db.Configuration
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
new IdentityRole<int>
{
    Id = 1,
    Name = "Admin",
    NormalizedName = "ADMIN",
    ConcurrencyStamp = "STATIC-ROLE-1"
},
new IdentityRole<int>
{
    Id = 2,
    Name = "NormalUser",
    NormalizedName = "NORMALUSER",
    ConcurrencyStamp = "STATIC-ROLE-2"
}
);
        }
    }
}
