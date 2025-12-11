using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Infra.Db.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "الکترونیک" },
                    { 2, "مد و پوشاک" },
                    { 3, "خانه و آشپزخانه" },
                    { 4, "زیبایی و بهداشت" },
                    { 5, "ورزش و سلامت" },
                    { 6, "کتاب و لوازم تهریر" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Username", "Wallet" },
                values: new object[,]
                {
                    { 1, "mahdi@gmail.com", "مهدی رضایی", "1234567", "mahdirr", 1000000000m },
                    { 2, "fatemeh@gmail.com", "فاطمه محمدی", "1234567", "fatemehm", 500000000m },
                    { 3, "hasan@gmail.com", "حسن نوری", "1234567", "hasannori", 200000000m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 5, "گوشی مدرن", "/File/ایفون 17.jpg", "آیفون 17 پرو", 300000000m },
                    { 2, 1, 10, "گوشی مدرن", "/File/16 پرو.jpg", "آیفون 16 پرو", 200000000m },
                    { 3, 1, 3, "گوشی مدرن", "/File/ایفون 16.jpg", "آیفون 16", 120000000m },
                    { 4, 1, 6, "گوشی مدرن", "/File/15 پ.jpg", "آیفون 15 پرو", 150000000m },
                    { 5, 1, 4, "گوشی مدرن", "/File/15 ن.jpg", "آیفون 15", 90000000m },
                    { 6, 1, 15, "لپتاپ مدرن", "/File/اچ پی.jpg", "لپ تاپ اچ پی", 200000000m },
                    { 8, 1, 12, "لپتاپ مدرن", "/File/لنوو.jpg", "لپتاب لنوو", 100000000m },
                    { 9, 1, 7, "پی اس پرو", "/File/پیاس5.jpg", "پی اس 5", 100000000m },
                    { 10, 1, 12, "لپتاپ مدرن", "/File/لنوو.jpg", "لپتاب لنوو", 100000000m },
                    { 11, 1, 10, "ایرپاد با کیفیت عالی", "/File/ایرپاد ایفون.jpg", "ایرپاد پرو مدل 1", 3500000m },
                    { 12, 1, 8, "نسل جدید ایرپاد", "/File/ایرپاد 1.jpg", "ایرپاد پرو مدل 2", 4200000m },
                    { 13, 1, 18, "کول پد حرفه‌ای", "/File/کول پد.jpg", "کول پد ساده مدل 2", 750000m },
                    { 14, 1, 25, "کول پد سبک", "/File/کول پد 2.jpg", "کول پد ساده مدل 3", 500000m },
                    { 15, 1, 17, "موس بی سیم", "/File/موس.jpg", "موس بی‌سیم 3", 550000m },
                    { 16, 1, 30, "پد موس نرم", "/File/پد موس.jpg", "پد موس طرح 1", 150000m },
                    { 17, 1, 28, "پد موس ضد لغزش", "/File/پد موس2.jpg", "پد موس طرح 2", 180000m },
                    { 18, 1, 22, "پد موس گیمینگ", "/File/پد موس 1.jpg", "پد موس طرح 3", 200000m },
                    { 19, 2, 12, "لباس زنانه شیک", "/File/لباس ز1.jpg", "لباس زنانه مدل 1", 450000m },
                    { 20, 2, 10, "لباس مجلسی", "/File/لباس ز2.jpg", "لباس زنانه مدل 2", 520000m },
                    { 21, 2, 9, "پیراهن مردانه", "/File/لباس1.jpg", "لباس مردانه مدل 2", 620000m },
                    { 22, 2, 13, "لباس اسپرت", "/File/لباس.jpg", "لباس مردانه مدل 3", 530000m },
                    { 23, 2, 10, "لباس کودک", "/File/لباس ب2.jpg", "لباس بچه‌گانه مدل 1", 300000m },
                    { 24, 2, 14, "لباس کودک", "/File/لباس ب1.jpg", "لباس بچه‌گانه مدل 2", 330000m },
                    { 25, 2, 12, "کفش روزمره", "/File/کفش2.jpg", "کفش مدل 4", 760000m },
                    { 26, 2, 9, "کفش اسپرت", "/File/کفش5.jpg", "کفش مدل 5", 890000m },
                    { 27, 2, 8, "کیف دستی", "/File/کیف1.jpeg", "کیف مدل 1", 550000m },
                    { 28, 2, 7, "کیف دستی", "/File/کیف2.jpg", "کیف مدل 2", 600000m },
                    { 29, 2, 10, "کیف دستی", "/File/کیف3.jpg", "کیف مدل 3", 450000m },
                    { 30, 3, 6, "قوری مقاوم", "/File/قوری.jpeg", "قوری شیشه ای", 300000m },
                    { 31, 3, 2, "مبل مدرن", "/File/مبل 1.jpg", "مبل مدل 1", 6000000m },
                    { 32, 3, 2, "مبل مدرن", "/File/مبل 3.jpg", "مبل مدل 2", 7200000m },
                    { 33, 3, 1, "مبل مدرن", "/File/مبل2.jpg", "مبل مدل 3", 6800000m },
                    { 34, 3, 1, "مبل سلطنتی", "/File/sofa4.jpg", "مبل مدل 4", 7900000m },
                    { 35, 3, 2, "تخت دو نفره", "/File/تخت1.jpg", "تخت خواب 1", 5000000m },
                    { 36, 3, 3, "تخت یک نفره", "/File/تخت2.jpg", "تخت خواب 2", 4200000m },
                    { 37, 3, 1, "تخت کلاسیک", "/File/تخت3.jpg", "تخت خواب 3", 6800000m },
                    { 38, 4, 10, "رژ لب بادوام", "/File/رژ.jpg", "رژ لب", 150000m },
                    { 39, 4, 20, "شامپو تقویتی", "/File/شامپو1.jpg", "شامپو مدل 1", 120000m },
                    { 40, 4, 18, "شامپو نرم‌کننده", "/File/شامپو.jpg", "شامپو مدل 2", 130000m },
                    { 41, 4, 18, "شوینده", "/File/شوینده2.jpg", "شوینده مدل 2", 130000m },
                    { 42, 5, 6, "دمبل ورزشی", "/File/دمبل.jpg", "دمبل 5 کیلویی", 350000m },
                    { 43, 5, 12, "طناب سبک", "/File/طناب.jpg", "طناب ورزشی", 90000m },
                    { 44, 5, 7, "کمربند بدنسازی", "/File/کمربندورزشی.jpg", "کمربند ورزشی", 200000m },
                    { 45, 6, 10, "کتاب داستانی", "/File/داستانی.jpg", "کتاب 1", 120000m },
                    { 46, 6, 9, "کتاب آموزشی", "/File/اموزشی.jpg", "کتاب 2", 150000m },
                    { 47, 6, 8, "کتاب روانشناسی", "/File/کتاب2.jpg", "کتاب 3", 180000m },
                    { 48, 6, 12, "کتاب روانشناسی", "/File/کتاب4.jpg", "کتاب 4", 110000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
