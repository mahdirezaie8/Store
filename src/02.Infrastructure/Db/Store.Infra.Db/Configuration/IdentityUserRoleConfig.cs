using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Infra.Db.Configuration
{
    public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(
      new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
      new IdentityUserRole<int> { UserId = 2, RoleId = 2 },
      new IdentityUserRole<int> { UserId = 3, RoleId = 2 }
  );
        }
    }
}
