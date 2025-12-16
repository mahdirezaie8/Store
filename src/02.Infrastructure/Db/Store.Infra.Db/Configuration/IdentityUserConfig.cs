using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Store.Infra.Db.Configuration
{
    public class IdentityUserConfig : IEntityTypeConfiguration<IdentityUser<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUser<int>> builder)
        {

            builder.HasData(
                new IdentityUser<int>
                {
                    Id = 1,
                    UserName = "mahdirr",
                    NormalizedUserName = "MAHDIRR",
                    Email = "mahdi@gmail.com",
                    NormalizedEmail = "MAHDI@GMAIL.COM",
                    EmailConfirmed = true,
                    SecurityStamp = "STATIC-STAMP-USER-1",
                    PasswordHash = "AQAAAAIAAYagAAAAEFSrkbE2H6hGEAgY0namdBZhyndFbmLVJJD5a0GlGq94AggqRttdUVAYRZy1ZUqLpw==",
                    ConcurrencyStamp = "STATIC-CONCURRENCY-1"
                }
            );

            builder.HasData(
    new IdentityUser<int>
    {
        Id = 2,
        UserName = "fatemehm",
        NormalizedUserName = "FATEMEH",
        Email = "fatemeh@gmail.com",
        NormalizedEmail = "FATEMEH@GMAIL.COM",
        EmailConfirmed = true,
        SecurityStamp = "STATIC-STAMP-USER-2",
        PasswordHash = "AQAAAAIAAYagAAAAEFSrkbE2H6hGEAgY0namdBZhyndFbmLVJJD5a0GlGq94AggqRttdUVAYRZy1ZUqLpw==",
        ConcurrencyStamp = "STATIC-CONCURRENCY-2"
    }
);

            builder.HasData(
    new IdentityUser<int>
    {
        Id = 3,
        UserName = "hasannori",
        NormalizedUserName = "HASANNORI",
        Email = "hasan@gmail.com",
        NormalizedEmail = "HASAN@GMAIL.COM",
        EmailConfirmed = true,
        SecurityStamp = "STATIC-STAMP-USER-3",
        PasswordHash = "AQAAAAIAAYagAAAAEFSrkbE2H6hGEAgY0namdBZhyndFbmLVJJD5a0GlGq94AggqRttdUVAYRZy1ZUqLpw==",
        ConcurrencyStamp = "STATIC-CONCURRENCY-3"
    }
);
        }
    }
}
