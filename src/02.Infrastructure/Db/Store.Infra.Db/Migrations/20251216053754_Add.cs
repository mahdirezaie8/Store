using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Infra.Db.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "STATIC-ROLE-1", "Admin", "ADMIN" },
                    { 2, "STATIC-ROLE-2", "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "STATIC-CONCURRENCY-1", "mahdi@gmail.com", true, false, null, "MAHDI@GMAIL.COM", "MAHDIRR", "AQAAAAIAAYagAAAAEFSrkbE2H6hGEAgY0namdBZhyndFbmLVJJD5a0GlGq94AggqRttdUVAYRZy1ZUqLpw==", null, false, "STATIC-STAMP-USER-1", false, "mahdirr" },
                    { 2, 0, "STATIC-CONCURRENCY-2", "fatemeh@gmail.com", true, false, null, "FATEMEH@GMAIL.COM", "FATEMEH", "AQAAAAIAAYagAAAAEFSrkbE2H6hGEAgY0namdBZhyndFbmLVJJD5a0GlGq94AggqRttdUVAYRZy1ZUqLpw==", null, false, "STATIC-STAMP-USER-2", false, "fatemehm" },
                    { 3, 0, "STATIC-CONCURRENCY-3", "hasan@gmail.com", true, false, null, "HASAN@GMAIL.COM", "HASANNORI", "AQAAAAIAAYagAAAAEFSrkbE2H6hGEAgY0namdBZhyndFbmLVJJD5a0GlGq94AggqRttdUVAYRZy1ZUqLpw==", null, false, "STATIC-STAMP-USER-3", false, "hasannori" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 }
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "IdentityUserId", "IsActive", "Password", "Role", "Username", "Wallet" },
                values: new object[,]
                {
                    { 1, "mahdi@gmail.com", "مهدی رضایی", 1, true, "123456", 0, "mahdirr", 1000000000m },
                    { 2, "fatemeh@gmail.com", "فاطمه محمدی", 2, true, "123456", 1, "fatemehm", 500000000m },
                    { 3, "hasan@gmail.com", "حسن نوری", 3, true, "123456", 1, "hasannori", 200000000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentityUserId",
                table: "Users",
                column: "IdentityUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
