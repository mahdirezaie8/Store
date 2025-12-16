using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Core.Entities;

namespace Store.Infra.Db.Configuration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(300);
            builder.HasData(new Category { Id = 1, Title = "الکترونیک" });
            builder.HasData(new Category { Id = 2, Title = "مد و پوشاک" });
            builder.HasData(new Category { Id = 3, Title = "خانه و آشپزخانه" });
            builder.HasData(new Category { Id = 4, Title = "زیبایی و بهداشت" });
            builder.HasData(new Category { Id = 5, Title = "ورزش و سلامت" });
            builder.HasData(new Category { Id = 6, Title = "کتاب و لوازم تهریر" });
        }
    }
}
