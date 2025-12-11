using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Core.Entities;

namespace Store.Infra.Db.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Image).IsRequired().HasMaxLength(300);
            builder.HasData(new Product { Id = 1, Name = "آیفون 17 پرو",CategoryId=1,Price=300000000,Count=5,Description="گوشی مدرن",Image= "/File/ایفون 17.jpg" });
            builder.HasData(new Product { Id = 2, Name = "آیفون 16 پرو", CategoryId = 1, Price = 200000000, Count =10, Description = "گوشی مدرن", Image = "/File/16 پرو.jpg" });
            builder.HasData(new Product { Id = 3, Name = "آیفون 16", CategoryId = 1, Price = 120000000, Count = 3, Description = "گوشی مدرن", Image = "/File/ایفون 16.jpg" });
            builder.HasData(new Product { Id = 4, Name = "آیفون 15 پرو", CategoryId = 1, Price = 150000000, Count = 6, Description = "گوشی مدرن", Image = "/File/15 پ.jpg" });
            builder.HasData(new Product { Id = 5, Name = "آیفون 15", CategoryId = 1, Price = 90000000, Count = 4, Description = "گوشی مدرن", Image = "/File/15 ن.jpg" });
            builder.HasData(new Product { Id = 6, Name = "لپ تاپ اچ پی", CategoryId = 1, Price = 200000000, Count =15, Description = "لپتاپ مدرن", Image = "/File/اچ پی.jpg" });
            builder.HasData(new Product { Id = 8, Name = "لپتاب لنوو", CategoryId = 1, Price = 100000000, Count = 12, Description = "لپتاپ مدرن", Image = "/File/لنوو.jpg" });
            builder.HasData(new Product { Id = 9, Name = "پی اس 5", CategoryId = 1, Price = 100000000, Count = 7, Description = "پی اس پرو", Image = "/File/پیاس5.jpg" });
            builder.HasData(new Product { Id = 10, Name = "لپتاب لنوو", CategoryId = 1, Price = 100000000, Count = 12, Description = "لپتاپ مدرن", Image = "/File/لنوو.jpg" });
            builder.HasData(new Product { Id = 11, Name = "ایرپاد پرو مدل 1", CategoryId = 1, Price = 3500000, Count = 10, Description = "ایرپاد با کیفیت عالی", Image = "/File/ایرپاد ایفون.jpg" });
            builder.HasData(new Product { Id = 12, Name = "ایرپاد پرو مدل 2", CategoryId = 1, Price = 4200000, Count = 8, Description = "نسل جدید ایرپاد", Image = "/File/ایرپاد 1.jpg" });
            builder.HasData(new Product { Id = 13, Name = "کول پد ساده مدل 2", CategoryId = 1, Price = 750000, Count = 18, Description = "کول پد حرفه‌ای", Image = "/File/کول پد.jpg" });
            builder.HasData(new Product { Id = 14, Name = "کول پد ساده مدل 3", CategoryId = 1, Price = 500000, Count = 25, Description = "کول پد سبک", Image = "/File/کول پد 2.jpg" });
            builder.HasData(new Product { Id = 15, Name = "موس بی‌سیم 3", CategoryId = 1, Price = 550000, Count = 17, Description = "موس بی سیم", Image = "/File/موس.jpg" });
            builder.HasData(new Product { Id = 16, Name = "پد موس طرح 1", CategoryId = 1, Price = 150000, Count = 30, Description = "پد موس نرم", Image = "/File/پد موس.jpg" });
            builder.HasData(new Product { Id = 17, Name = "پد موس طرح 2", CategoryId = 1, Price = 180000, Count = 28, Description = "پد موس ضد لغزش", Image = "/File/پد موس2.jpg" });
            builder.HasData(new Product { Id = 18, Name = "پد موس طرح 3", CategoryId = 1, Price = 200000, Count = 22, Description = "پد موس گیمینگ", Image = "/File/پد موس 1.jpg" });
            builder.HasData(new Product { Id = 19, Name = "لباس زنانه مدل 1", CategoryId =2, Price = 450000, Count = 12, Description = "لباس زنانه شیک", Image = "/File/لباس ز1.jpg" });
            builder.HasData(new Product { Id = 20, Name = "لباس زنانه مدل 2", CategoryId = 2, Price = 520000, Count = 10, Description = "لباس مجلسی", Image = "/File/لباس ز2.jpg" });
            builder.HasData(new Product { Id = 21, Name = "لباس مردانه مدل 2", CategoryId = 2, Price = 620000, Count = 9, Description = "پیراهن مردانه", Image = "/File/لباس1.jpg" });
            builder.HasData(new Product { Id = 22, Name = "لباس مردانه مدل 3", CategoryId = 2, Price = 530000, Count = 13, Description = "لباس اسپرت", Image = "/File/لباس.jpg" });
            builder.HasData(new Product { Id = 23, Name = "لباس بچه‌گانه مدل 1", CategoryId = 2, Price = 300000, Count = 10, Description = "لباس کودک", Image = "/File/لباس ب2.jpg" });
            builder.HasData(new Product { Id = 24, Name = "لباس بچه‌گانه مدل 2", CategoryId = 2, Price = 330000, Count = 14, Description = "لباس کودک", Image = "/File/لباس ب1.jpg" });
            builder.HasData(new Product { Id = 25, Name = "کفش مدل 4", CategoryId = 2, Price = 760000, Count = 12, Description = "کفش روزمره", Image = "/File/کفش2.jpg" });
            builder.HasData(new Product { Id = 26, Name = "کفش مدل 5", CategoryId = 2, Price = 890000, Count = 9, Description = "کفش اسپرت", Image = "/File/کفش5.jpg" });
            builder.HasData(new Product { Id = 27, Name = "کیف مدل 1", CategoryId = 2, Price = 550000, Count = 8, Description = "کیف دستی", Image = "/File/کیف1.jpeg" });
            builder.HasData(new Product { Id = 28, Name = "کیف مدل 2", CategoryId = 2, Price = 600000, Count = 7, Description = "کیف دستی", Image = "/File/کیف2.jpg" });
            builder.HasData(new Product { Id = 29, Name = "کیف مدل 3", CategoryId = 2, Price = 450000, Count = 10, Description = "کیف دستی", Image = "/File/کیف3.jpg" });
            builder.HasData(new Product { Id = 30, Name = "قوری شیشه ای", CategoryId = 3, Price = 300000, Count = 6, Description = "قوری مقاوم", Image = "/File/قوری.jpeg" });
            builder.HasData(new Product { Id = 31, Name = "مبل مدل 1", CategoryId = 3, Price = 6000000, Count = 2, Description = "مبل مدرن", Image = "/File/مبل 1.jpg" });
            builder.HasData(new Product { Id = 32, Name = "مبل مدل 2", CategoryId = 3, Price = 7200000, Count = 2, Description = "مبل مدرن", Image = "/File/مبل 3.jpg" });
            builder.HasData(new Product { Id = 33, Name = "مبل مدل 3", CategoryId = 3, Price = 6800000, Count = 1, Description = "مبل مدرن", Image = "/File/مبل2.jpg" });
            builder.HasData(new Product { Id = 35, Name = "تخت خواب 1", CategoryId = 3, Price = 5000000, Count = 2, Description = "تخت دو نفره", Image = "/File/تخت1.jpg" });
            builder.HasData(new Product { Id = 36, Name = "تخت خواب 2", CategoryId =3, Price = 4200000, Count = 3, Description = "تخت یک نفره", Image = "/File/تخت2.jpg" });
            builder.HasData(new Product { Id = 37, Name = "تخت خواب 3", CategoryId = 3, Price = 6800000, Count = 1, Description = "تخت کلاسیک", Image = "/File/تخت3.jpg" });
            builder.HasData(new Product { Id = 38, Name = "رژ لب", CategoryId = 4, Price = 150000, Count = 10, Description = "رژ لب بادوام", Image = "/File/رژ.jpg" });
            builder.HasData(new Product { Id = 39, Name = "شامپو مدل 1", CategoryId = 4, Price = 120000, Count = 20, Description = "شامپو تقویتی", Image = "/File/شامپو1.jpg" });
            builder.HasData(new Product { Id = 40, Name = "شامپو مدل 2", CategoryId = 4, Price = 130000, Count = 18, Description = "شامپو نرم‌کننده", Image = "/File/شامپو.jpg" });
            builder.HasData(new Product { Id = 41, Name = "شوینده مدل 2", CategoryId = 4, Price = 130000, Count = 18, Description = "شوینده", Image = "/File/شوینده2.jpg" });
            builder.HasData(new Product { Id = 42, Name = "دمبل 5 کیلویی", CategoryId = 5, Price = 350000, Count = 6, Description = "دمبل ورزشی", Image = "/File/دمبل.jpg" });
            builder.HasData(new Product { Id = 43, Name = "طناب ورزشی", CategoryId = 5, Price = 90000, Count = 12, Description = "طناب سبک", Image = "/File/طناب.jpg" });
            builder.HasData(new Product { Id = 44, Name = "کمربند ورزشی", CategoryId = 5, Price = 200000, Count = 7, Description = "کمربند بدنسازی", Image = "/File/کمربندورزشی.jpg" });
            builder.HasData(new Product { Id = 45, Name = "کتاب 1", CategoryId = 6, Price = 120000, Count = 10, Description = "کتاب داستانی", Image = "/File/داستانی.jpg" });
            builder.HasData(new Product { Id = 46, Name = "کتاب 2", CategoryId = 6, Price = 150000, Count = 9, Description = "کتاب آموزشی", Image = "/File/اموزشی.jpg" });
            builder.HasData(new Product { Id = 47, Name = "کتاب 3", CategoryId = 6, Price = 180000, Count = 8, Description = "کتاب روانشناسی", Image = "/File/کتاب2.jpg" });
            builder.HasData(new Product { Id = 48, Name = "کتاب 4", CategoryId =6, Price = 110000, Count = 12, Description = "کتاب روانشناسی", Image = "/File/کتاب4.jpg" });


        }
    }
}
