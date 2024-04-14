using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStore.App.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Filter = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InfoLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameDetailed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpecificationValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metric = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationValues_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartNumbers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecificationValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SpecificationValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationValues_SpecificationValues_SpecificationValueId",
                        column: x => x.SpecificationValueId,
                        principalTable: "SpecificationValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "FilePath", "Name", "Url" },
                values: new object[,]
                {
                    { 5, "Images/Layout/nav-cpu.png", "Processor", null },
                    { 6, "Images/Layout/nav-cpucooler.png", "Cooler", null },
                    { 7, "Images/Layout/nav-motherboard.png", "Motherboard", null },
                    { 8, "Images/Layout/nav-memory.png", "Memory", null },
                    { 9, "Images/Layout/nav-ssd.png", "Storage", null },
                    { 10, "Images/Layout/nav-videocard.png", "Video Card", null },
                    { 11, "Images/Layout/nav-powersupply.png", "Power Supply", null },
                    { 12, "Images/Layout/nav-case.png", "Case", null },
                    { 13, "Images/Layout/nav-headphones.jpg", "Headphones", null },
                    { 14, "Images/Layout/nav-kb.jpg", "Keyboard", null },
                    { 15, "Images/Layout/nav-mouse.png", "Mouse", null },
                    { 16, "Images/Layout/nav-sp.jpg", "Speakers", null },
                    { 17, "Images/Layout/nav-wc.jpg", "Webcam", null },
                    { 18, "Images/Layout/nav-mon.jpg", "Monitor", null }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "AMD" },
                    { 4, "Intel" },
                    { 5, "Coooler Master" },
                    { 6, "be quiet!" },
                    { 7, "Corsair" },
                    { 8, "MSI" },
                    { 9, "Gigabyte" },
                    { 10, "G.Skill" },
                    { 11, "Samsung" },
                    { 12, "Seagate" },
                    { 13, "Kingston" },
                    { 14, "Cruical" },
                    { 15, "Asus" },
                    { 16, "Thremaltake" },
                    { 17, "EVGA" },
                    { 18, "Deepcool" },
                    { 19, "NZXT" },
                    { 20, "Lian Li" },
                    { 21, "Fractal Design" },
                    { 22, "HP" },
                    { 23, "Razer" },
                    { 24, "Logitech" },
                    { 25, "Creative Labs" },
                    { 26, "AOC" },
                    { 27, "LG" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ManufacturerId", "Name", "NameDetailed", "Price" },
                values: new object[,]
                {
                    { 3, 5, 3, "AMD Ryzen 5 5600X", "AMD Ryzen 5 5600X 3.7 GHz 6-Core Processor", 0m },
                    { 4, 5, 3, "AMD Ryzen 7 7800X3D", "AMD Ryzen 7 7800X3D 4.2 GHz 8-Core Processor", 0m },
                    { 5, 5, 4, "Intel Core i7-13700K", "Intel Core i7-13700K 3.4 GHz 16-Core Processor", 0m },
                    { 6, 5, 3, "AMD Ryzen 7 5800X", "AMD Ryzen 7 5800X 3.8 GHz 8-Core Processor", 0m },
                    { 7, 6, 5, "Cooler Master Hyper 212 Black Edition", "Cooler Master Hyper 212 Black Edition 42 CFM CPU Cooler", 0m },
                    { 8, 6, 5, "Cooler Master MASTERLIQUID ML240L RGB V2", "Cooler Master MASTERLIQUID ML240L RGB V2 65.59 CFM Liquid CPU Cooler", 0m },
                    { 9, 6, 6, "be quiet! Dark Rock Pro 4", "be quiet! Dark Rock Pro 4 50.5 CFM CPU Cooler", 0m },
                    { 10, 6, 7, "Corsair iCUE H150i ELITE CAPELLIX XT", "Corsair iCUE H150i ELITE CAPELLIX XT 65.57 CFM Liquid CPU Cooler", 0m },
                    { 11, 7, 8, "MSI B550 GAMING GEN3", "MSI B550 GAMING GEN3 ATX AM4 Motherboard", 0m },
                    { 12, 7, 9, "Gigabyte B650 AORUS ELITE AX", "Gigabyte B650 AORUS ELITE AX ATX AM5 Motherboard", 0m },
                    { 13, 7, 8, "MSI MAG B550 TOMAHAWK", "MSI MAG B550 TOMAHAWK ATX AM4 Motherboard", 0m },
                    { 14, 7, 9, "Gigabyte Z790 AORUS ELITE AX", "Gigabyte Z790 AORUS ELITE AX ATX LGA1700 Motherboard", 0m },
                    { 15, 8, 7, "Corsair Vengeance LPX 16 GB", "Corsair Vengeance LPX 16 GB (2 x 8 GB) DDR4-3200 CL16 Memory", 0m },
                    { 16, 8, 7, "Corsair Vengeance 32 GB", "Corsair Vengeance 32 GB (2 x 16 GB) DDR5-5600 CL36 Memory", 0m },
                    { 17, 8, 7, "Corsair Vengeance RGB Pro 32 GB", "Corsair Vengeance RGB Pro 32 GB (2 x 16 GB) DDR4-3600 CL18 Memory", 0m },
                    { 18, 8, 10, "G.Skill Trident Z5 RGB 32 GB", "G.Skill Trident Z5 RGB 32 GB (2 x 16 GB) DDR5-6000 CL36 Memory", 0m },
                    { 19, 9, 11, "Samsung 980 Pro", "Samsung 980 Pro 2 TB M.2-2280 PCIe 4.0 X4 NVME Solid State Drive", 0m },
                    { 20, 9, 12, "Seagate Barracuda Compute", "Seagate Barracuda Compute 2 TB 3.5\" 7200 RPM Internal Hard Drive", 0m },
                    { 21, 9, 13, "Kingston A400", "Kingston A400 240 GB 2.5\" Solid State Drive", 0m },
                    { 22, 9, 14, "Crucial P3", "Crucial P3 4 TB M.2-2280 PCIe 3.0 X4 NVME Solid State Drive", 0m },
                    { 23, 10, 8, "MSI GeForce RTX 3060 Ventus 2X 12G", "MSI GeForce RTX 3060 Ventus 2X 12G GeForce RTX 3060 12GB 12 GB Video Card", 0m },
                    { 24, 10, 9, "Gigabyte WINDFORCE OC", "Gigabyte WINDFORCE OC GeForce RTX 4070 12 GB Video Card", 0m },
                    { 25, 10, 15, "Asus ROG STRIX GAMING OC", "Asus ROG STRIX GAMING OC GeForce RTX 4090 24 GB Video Card", 0m },
                    { 26, 10, 8, "MSI RTX 3060 Ventus 3X 12G OC", "MSI RTX 3060 Ventus 3X 12G OC GeForce RTX 3060 12GB 12 GB Video Card", 0m },
                    { 27, 11, 7, "Corsair RM750e (2023)", "Corsair RM750e (2023) 750 W 80+ Gold Certified Fully Modular ATX Power Supply", 0m },
                    { 28, 11, 16, "Thermaltake Toughpower GX2", "Thermaltake Toughpower GX2 600 W 80+ Gold Certified ATX Power Supply", 0m },
                    { 29, 11, 8, "MSI MPG A650GF", "MSI MPG A650GF 650 W 80+ Gold Certified Fully Modular ATX Power Supply", 0m },
                    { 30, 11, 17, "EVGA 500 W1", "EVGA 500 W1 500 W 80+ Certified ATX Power Supply", 0m },
                    { 31, 12, 18, "Deepcool CC560", "Deepcool CC560 ATX Mid Tower Case", 0m },
                    { 32, 12, 19, "NZXT H5 Flow", "NZXT H5 Flow ATX Mid Tower Case", 0m },
                    { 33, 12, 20, "Lian Li O11 Dynamic EVO", "Lian Li O11 Dynamic EVO ATX Mid Tower Case", 0m },
                    { 34, 12, 21, "Fractal Design North", "Fractal Design North ATX Mid Tower Case", 0m },
                    { 35, 13, 22, "HP HyperX Cloud II", "HP HyperX Cloud II 7.1 Channel Headset", 0m },
                    { 36, 13, 23, "Razer BlackShark V2 X", "Razer BlackShark V2 X 7.1 Channel Headset", 0m },
                    { 37, 13, 24, "Logitech Pro X", "Logitech Pro X 7.1 Channel Headset", 0m },
                    { 38, 13, 23, "Razer Kraken Kitty", "Razer Kraken Kitty Headset", 0m },
                    { 39, 14, 7, "Corsair K60 RGB Pro", "Corsair K60 RGB Pro Wired Gaming Keyboard", 0m },
                    { 40, 14, 24, "Logitech K120", "Logitech K120 Wired Standard Keyboard", 0m },
                    { 41, 14, 23, "Razer Huntsman Mini", "Razer Huntsman Mini RGB Wired Mini Keyboard", 0m },
                    { 42, 14, 23, "Razer BlackWidow V3", "Razer BlackWidow V3 RGB Wired Gaming Keyboard", 0m },
                    { 43, 15, 24, "Logitech G502 HERO", "Logitech G502 HERO Wired Optical Mouse", 0m },
                    { 44, 15, 23, "Razer Basilisk V3", "Razer Basilisk V3 Wired Optical Mouse", 0m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ManufacturerId", "Name", "NameDetailed", "Price" },
                values: new object[,]
                {
                    { 45, 15, 23, "Razer DeathAdder Essential", "Razer DeathAdder Essential Wired Optical Mouse", 0m },
                    { 46, 15, 23, "Razer Viper Mini", "Razer Viper Mini Wired Optical Mouse", 0m },
                    { 47, 16, 24, "Logitech Z200", "Logitech Z200 10 W Speakers", 0m },
                    { 48, 16, 24, "Logitech Z906", "Logitech Z906 500 W 5.1-Channel Speakers", 0m },
                    { 49, 16, 23, "Razer Leviathan V2", "Razer Leviathan V2 65 W 2.1-Channel Speakers", 0m },
                    { 50, 16, 25, "Creative Labs Creative Stage V2", "Creative Labs Creative Stage V2 80 W 2.1-Channel Speakers", 0m },
                    { 51, 17, 24, "Logitech BRIO Ultra HD Pro", "Logitech BRIO Ultra HD Pro Webcam", 0m },
                    { 52, 17, 23, "Razer Kiyo Pro Ultra", "Razer Kiyo Pro Ultra Webcam", 0m },
                    { 53, 18, 15, "Asus TUF Gaming VG27AQ", "Asus TUF Gaming VG27AQ 27.0\" 2560 x 1440 165 Hz Monitor", 0m },
                    { 54, 18, 11, "Samsung Odyssey G7", "Samsung Odyssey G7 27.0\" 2560 x 1440 240 Hz Curved Monitor", 0m },
                    { 55, 18, 26, "AOC C27G2Z", "AOC C27G2Z 27.0\" 1920 x 1080 240 Hz Curved Monitor", 0m },
                    { 56, 17, 24, "Logitech C270", "Logitech C270 Webcam", 0m },
                    { 57, 17, 23, "Razer Kiyo", "Razer Kiyo Webcam", 0m },
                    { 58, 18, 27, "LG UltraGear", "LG UltraGear 27.0\" 2560 x 1440 165 Hz Monitor", 0m }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 9, 5, true, "Essential", "Core Count" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 10, 5, "Essential", "Performance Core Clock" },
                    { 11, 5, "Essential", "Performance Boost Clock" },
                    { 12, 5, null, "TDP" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 13, 5, true, "Essential", "Series" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 14, 5, null, "Microarchitecture" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 15, 5, true, "Essential", "Core Family" },
                    { 16, 5, true, "Essential", "Socket" },
                    { 17, 5, true, null, "Integrated Graphics" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 18, 5, null, "Maximum Supported Memory" },
                    { 19, 5, null, "ECC Support" },
                    { 20, 5, null, "Includes Cooler" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 21, 5, true, null, "Packaging" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 22, 5, null, "Performance L1 Cache" },
                    { 23, 5, null, "Performance L2 Cache" },
                    { 24, 5, null, "L3 Cache" },
                    { 25, 5, null, "Lithography" },
                    { 26, 5, null, "Includes CPU Cooler" },
                    { 27, 5, null, "Simultaneous Multithreading" },
                    { 28, 5, null, "Efficiency L1 Cache" },
                    { 29, 5, null, "Efficiency L2 Cache" },
                    { 30, 6, null, "Model" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 31, 6, true, "Essential", "Fan RPM" },
                    { 32, 6, true, "Essential", "Noise Level" },
                    { 33, 6, true, "Essential", "Height" },
                    { 34, 6, true, "Essential", "Water Cooled" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 35, 6, null, "Fanless" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 36, 6, true, null, "CPU Socket" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 37, 6, true, null, "Color" },
                    { 38, 7, true, "Essential", "Socket / CPU" },
                    { 39, 7, true, "Essential", "Form Factor" },
                    { 40, 7, true, "Essential", "Chipset" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 41, 7, null, "Memory Max" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 42, 7, true, "Essential", "Memory Type" },
                    { 43, 7, true, "Essential", "Memory Slots" },
                    { 44, 7, true, null, "Color" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 45, 7, null, "SLI/CrossFire" },
                    { 46, 7, null, "PCIe x16 Slots" },
                    { 47, 7, null, "PCIe x8 Slots" },
                    { 48, 7, null, "PCIe x4 Slots" },
                    { 49, 7, null, "PCIe x1 Slots" },
                    { 50, 7, null, "PCI Slots" },
                    { 51, 7, null, "M.2 Slots" },
                    { 52, 7, null, "Mini-PCIe Slots" },
                    { 53, 7, null, "Half Mini-PCIe Slots" },
                    { 54, 7, null, "Mini-PCIe / mSATA Slots" },
                    { 55, 7, null, "mSATA Slots" },
                    { 56, 7, null, "SATA 6.0 Gb/s" },
                    { 57, 7, null, "Onboard Ethernet" },
                    { 58, 7, null, "Onboard Video" },
                    { 59, 7, null, "USB 2.0 Headers" },
                    { 60, 7, null, "USB 2.0 Headers (Single Port)" },
                    { 61, 7, null, "USB 3.2 Gen 1 Headers" },
                    { 62, 7, null, "USB 3.2 Gen 2 Headers" },
                    { 63, 7, null, "USB 3.2 Gen 2x2 Headers" },
                    { 64, 7, null, "Supports ECC" },
                    { 65, 7, null, "Wireless Networking" },
                    { 66, 7, null, "RAID Support" },
                    { 67, 7, null, "Memory Speed" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 68, 8, true, "Essential", "Speed" },
                    { 69, 8, true, "Essential", "Form Factor" },
                    { 70, 8, true, "Essential", "Modules" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 71, 8, null, "Price / GB" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 72, 8, true, null, "Color" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 73, 8, null, "First Word Latency" },
                    { 74, 8, null, "CAS Latency" },
                    { 75, 8, null, "Voltage" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 76, 8, true, "Essential", "Timing" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 77, 8, null, "ECC / Registered" },
                    { 78, 8, null, "Heat Spreader" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 79, 9, true, "Essential", "Capacity" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 80, 9, null, "Price / GB" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 81, 9, true, "Essential", "Type" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 82, 9, null, "Cache" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 83, 9, true, "Essential", "Form Factor" },
                    { 84, 9, true, "Essential", "Interface" },
                    { 85, 9, true, null, "NVME" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 86, 10, null, "Model" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 87, 10, true, "Essential", "Chipset" },
                    { 88, 10, true, "Essential", "Memory" },
                    { 89, 10, true, "Essential", "Memory Type" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 90, 10, "Essential", "Core Clock" },
                    { 91, 10, "Essential", "Boost Clock" },
                    { 92, 10, null, "Effective Memory Clock" },
                    { 93, 10, null, "Interface" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 94, 10, true, null, "Color" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 95, 10, null, "Frame Sync" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 96, 10, true, null, "Length" },
                    { 97, 10, true, null, "TDP" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 98, 10, null, "Case Expansion Slot Width" },
                    { 99, 10, null, "Total Slot Width" },
                    { 100, 10, null, "Cooling" },
                    { 101, 10, null, "External Power" },
                    { 102, 10, null, "HDMI Outputs" },
                    { 103, 10, null, "DisplayPort Outputs" },
                    { 104, 10, null, "HDMI 2.1a Outputs" },
                    { 105, 10, null, "DisplayPort 1.4 Outputs" },
                    { 106, 10, null, "DisplayPort 1.4a Outputs" },
                    { 107, 11, null, "Model" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 108, 11, true, "Essential", "Type" },
                    { 109, 11, true, "Essential", "Efficiency Rating" },
                    { 110, 11, true, "Essential", "Wattage" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 111, 11, null, "Length" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 112, 11, true, "Essential", "Modular" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 113, 11, null, "Color" },
                    { 114, 11, null, "Fanless" },
                    { 115, 11, null, "ATX 4-Pin Connectors" },
                    { 116, 11, null, "EPS 8-Pin Connectors" },
                    { 117, 11, null, "PCIe 12+4-Pin 12VHPWR Connectors" },
                    { 118, 11, null, "PCIe 12-Pin Connectors" },
                    { 119, 11, null, "PCIe 8-Pin Connectors" },
                    { 120, 11, null, "PCIe 6+2-Pin Connectors" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 121, 11, null, "PCIe 6-Pin Connectors" },
                    { 122, 11, null, "SATA Connectors" },
                    { 123, 11, null, "Molex 4-Pin Connectors" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 124, 12, true, "Essential", "Type" },
                    { 125, 12, true, "Essential", "Color" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 126, 12, null, "Power Supply" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 127, 12, true, "Essential", "Side Panel" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 128, 12, null, "Power Supply Shroud" },
                    { 129, 12, null, "Front Panel USB" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 130, 12, true, null, "Motherboard Form Factor" },
                    { 131, 12, true, null, "Maximum Video Card Length" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 132, 12, null, "Drive Bays" },
                    { 133, 12, null, "Expansion Slots" },
                    { 134, 12, null, "Dimensions" },
                    { 135, 12, null, "Volume" },
                    { 136, 13, null, "Model" },
                    { 137, 13, null, "Type" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 138, 13, true, null, "Frequency Response" },
                    { 139, 13, true, null, "Microphone" },
                    { 140, 13, true, "Essential", "Wireless" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 141, 13, null, "Enclosure Type" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 142, 13, true, null, "Color" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 143, 13, null, "Active Noise Cancelling" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 144, 13, true, null, "Connection" },
                    { 145, 13, true, "Essential", "Channels" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 146, 13, "Essential", "Impedance" },
                    { 147, 13, null, "Sensitivity at 1 V RMS" },
                    { 148, 13, null, "Cord Length" },
                    { 149, 14, null, "Model" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 150, 14, true, "Essential", "Style" },
                    { 151, 14, true, "Essential", "Mechanical" },
                    { 152, 14, true, "Essential", "Switch Type" },
                    { 153, 14, true, "Essential", "Backlit" },
                    { 154, 14, true, null, "Tenkeyless" },
                    { 155, 14, true, "Essential", "Connection Type" },
                    { 156, 14, true, null, "Color" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 157, 14, null, "Mouse Included" },
                    { 158, 15, null, "Model" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 159, 15, true, "Essential", "Tracking Method" },
                    { 160, 15, true, "Essential", "Connection Type" },
                    { 161, 15, true, "Essential", "Maximum DPI" },
                    { 162, 15, true, "Essential", "Hand Orientation" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 163, 15, null, "Color" },
                    { 164, 16, null, "Model" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 165, 16, true, "Essential", "Configuration" },
                    { 166, 16, true, null, "Total Wattage" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 167, 16, null, "Frequency Response" },
                    { 168, 16, null, "Power (Front, Each)" },
                    { 169, 16, null, "Power (Center)" },
                    { 170, 16, null, "Power (Rear, Each)" },
                    { 171, 16, null, "Power (Subwoofer)" },
                    { 172, 16, null, "Color" },
                    { 173, 17, null, "Model" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 174, 17, true, "Essential", "Resolution" },
                    { 175, 17, true, "Essential", "Connection" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 176, 17, null, "Focus Type" },
                    { 177, 17, null, "Operating System" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 178, 17, true, "Essential", "FOV Angle" },
                    { 179, 17, true, "Essential", "Digital Zoom" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 180, 17, null, "Privacy Shutter" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 181, 17, true, null, "Built-In Lighting" },
                    { 182, 17, true, null, "Automatic Lighting Adjust" },
                    { 183, 17, true, null, "Supports Windows Hello" },
                    { 184, 17, true, "Essential", "Sensor Pixels" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 185, 18, null, "Model" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 186, 18, true, "Essential", "Screen Size" },
                    { 187, 18, true, "Essential", "Resolution" },
                    { 188, 18, true, "Essential", "Refresh Rate" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[] { 189, 18, null, "Response Time (G2G)" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[] { 190, 18, true, "Essential", "Panel Type" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 191, 18, null, "Aspect Ratio" },
                    { 192, 18, null, "Color" },
                    { 193, 18, null, "Brightness" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "Filter", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 194, 18, true, null, "Widescreen" },
                    { 195, 18, true, null, "Curved Screen" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CategoryId", "InfoLevel", "Name" },
                values: new object[,]
                {
                    { 196, 18, null, "Frame Sync" },
                    { 197, 18, null, "Built-in Speakers" },
                    { 198, 18, null, "Viewing Angle" },
                    { 199, 18, null, "Inputs" },
                    { 200, 18, null, "HDR Tier" },
                    { 201, 18, null, "Curvature Radius" },
                    { 202, 18, null, "Response Time (MPRT)" },
                    { 203, 18, null, "VESA Mounting" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FilePath", "MainImage", "ProductId", "Url" },
                values: new object[,]
                {
                    { "00f7b9f8-49fc-45a3-a8fa-43a0c96b62dd", "/Images/00f7b9f8-49fc-45a3-a8fa-43a0c96b62dd.jpg", null, 24, "https://cdna.pcpartpicker.com/static/forever/images/product/772cce097c55469671a0d75ea4aca83a.1600.jpg" },
                    { "03c91e40-c117-460a-8454-60ca9e771c38", "/Images/03c91e40-c117-460a-8454-60ca9e771c38.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/f2d189697dd22bdee32e3f78ac93ecf6.1600.jpg" },
                    { "04d4d665-98b4-40ed-83de-9b7cf3311444", "/Images/04d4d665-98b4-40ed-83de-9b7cf3311444.jpg", null, 4, "https://cdna.pcpartpicker.com/static/forever/images/product/f0e0e59d75066ec825667b71c31e3c83.1600.jpg" },
                    { "06d3b2eb-ac3a-47a7-82a5-e363d20096f1", "/Images/06d3b2eb-ac3a-47a7-82a5-e363d20096f1.jpg", null, 15, "https://cdna.pcpartpicker.com/static/forever/images/product/0d7ccc6bb32c1a857bdfc56d9eb74081.1600.jpg" },
                    { "09230f47-7964-4e73-b4ce-4fd9d613f0a5", "/Images/09230f47-7964-4e73-b4ce-4fd9d613f0a5.jpg", null, 12, "https://cdna.pcpartpicker.com/static/forever/images/product/bcc3861f5dd336421becec729f2ac903.1600.jpg" },
                    { "09c41293-55d6-4bb2-ab31-0f127ee7318c", "/Images/09c41293-55d6-4bb2-ab31-0f127ee7318c.jpg", null, 30, "https://m.media-amazon.com/images/I/41T5OeHmOJL.jpg" },
                    { "0be57707-e0c2-4177-af7a-591415d0c00a", "/Images/0be57707-e0c2-4177-af7a-591415d0c00a.jpg", null, 44, "https://cdna.pcpartpicker.com/static/forever/images/product/0607ed766f65ab17807168b707b7580c.1600.jpg" },
                    { "0bf93fd0-19e8-4486-a08c-bfe097bb1c22", "/Images/0bf93fd0-19e8-4486-a08c-bfe097bb1c22.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/589fcb12f6c675045fa379c9f7169c4d.1600.jpg" },
                    { "0e6086b0-4555-4f77-8bce-2cc581472780", "/Images/0e6086b0-4555-4f77-8bce-2cc581472780.jpg", null, 22, "https://m.media-amazon.com/images/I/318lV0rfJoL.jpg" },
                    { "11f02df0-ed66-410c-a126-f1147ae4a54c", "/Images/11f02df0-ed66-410c-a126-f1147ae4a54c.jpg", null, 32, "https://cdna.pcpartpicker.com/static/forever/images/product/8651013bcb8890048e06820902e927db.1600.jpg" },
                    { "11f11e54-3c3a-4257-bd90-9bf8de1393b2", "/Images/11f11e54-3c3a-4257-bd90-9bf8de1393b2.jpg", null, 51, "https://cdna.pcpartpicker.com/static/forever/images/product/6c931846f8b1f5346a3700526272ea24.1600.jpg" },
                    { "12fe677c-7697-48f6-bf52-64c3df981a26", "/Images/12fe677c-7697-48f6-bf52-64c3df981a26.jpg", null, 18, "https://cdna.pcpartpicker.com/static/forever/images/product/41e3e55e5ef124b218bfec3b3b243ca3.1600.jpg" },
                    { "17a14db7-ad18-4a06-a149-4a6872d77972", "/Images/17a14db7-ad18-4a06-a149-4a6872d77972.jpg", null, 56, "https://cdna.pcpartpicker.com/static/forever/images/product/2ea46c5847b08c504b33b7d4c8ef39d7.1600.jpg" },
                    { "202af0b0-41f3-4744-a862-483fd01a92b2", "/Images/202af0b0-41f3-4744-a862-483fd01a92b2.jpg", null, 39, "https://cdna.pcpartpicker.com/static/forever/images/product/0fa355840792cb24746bbb4200368282.1600.jpg" },
                    { "20ae62e9-42aa-4969-8cf6-ad878e2fb573", "/Images/20ae62e9-42aa-4969-8cf6-ad878e2fb573.jpg", null, 31, "https://m.media-amazon.com/images/I/41yIE8KxulL.jpg" },
                    { "21b8572c-f178-4ba9-9308-475b9a3ac2b3", "/Images/21b8572c-f178-4ba9-9308-475b9a3ac2b3.jpg", null, 15, "https://cdna.pcpartpicker.com/static/forever/images/product/835ab3efad1be13bbe53beef3e3c6f96.1600.jpg" },
                    { "24f043ca-72a5-4bb6-8580-2e1907613542", "/Images/24f043ca-72a5-4bb6-8580-2e1907613542.jpg", null, 31, "https://m.media-amazon.com/images/I/41WfYdvzk5L.jpg" },
                    { "252a502e-94fe-42ef-b287-9883a9c631ae", "/Images/252a502e-94fe-42ef-b287-9883a9c631ae.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/105c8b0ca528860487720c77b236bca9.1600.jpg" },
                    { "2553abe7-63c8-4da5-b338-a899d0a80e8b", "/Images/2553abe7-63c8-4da5-b338-a899d0a80e8b.jpg", null, 13, "https://cdna.pcpartpicker.com/static/forever/images/product/52ee465cbd64b16145232d863524c066.1600.jpg" },
                    { "2593176e-20bf-4392-9b27-1abfbcb1d1c2", "/Images/2593176e-20bf-4392-9b27-1abfbcb1d1c2.jpg", null, 30, "https://m.media-amazon.com/images/I/41iw-jgJj8L.jpg" },
                    { "274c6543-3980-4c11-8664-2f618907e7e8", "/Images/274c6543-3980-4c11-8664-2f618907e7e8.jpg", null, 52, "https://cdna.pcpartpicker.com/static/forever/images/product/f0281d7b65771dacec49d796123aa7f6.1600.jpg" },
                    { "28e8257b-25d3-4114-b523-c0f778129fe1", "/Images/28e8257b-25d3-4114-b523-c0f778129fe1.jpg", null, 46, "https://cdna.pcpartpicker.com/static/forever/images/product/8da02f4b1cae5ccffadffc74272e4e01.1600.jpg" },
                    { "28e968e1-e5a1-4532-a11a-775cfc02f114", "/Images/28e968e1-e5a1-4532-a11a-775cfc02f114.jpg", null, 3, "https://cdna.pcpartpicker.com/static/forever/images/product/aea586ed783a4fba090978dfab85b886.1600.jpg" },
                    { "2b9e3dac-3cc8-43e3-bfb8-b63118fccffe", "/Images/2b9e3dac-3cc8-43e3-bfb8-b63118fccffe.jpg", null, 31, "https://m.media-amazon.com/images/I/31YAOE3okkL.jpg" },
                    { "319d5f95-24c2-434a-82b0-3462b0ddf4b3", "/Images/319d5f95-24c2-434a-82b0-3462b0ddf4b3.jpg", null, 45, "https://cdna.pcpartpicker.com/static/forever/images/product/1435c1dd5733f7443c14b484e733224e.1600.jpg" },
                    { "32792424-48fe-4e32-9fe7-241afc3c215d", "/Images/32792424-48fe-4e32-9fe7-241afc3c215d.jpg", null, 31, "https://m.media-amazon.com/images/I/31cNL+9TWsL.jpg" },
                    { "33848993-28f5-468f-8a2d-1d2d2cc160c2", "/Images/33848993-28f5-468f-8a2d-1d2d2cc160c2.jpg", null, 53, "https://m.media-amazon.com/images/I/31OAVlJoj8L.jpg" },
                    { "3667240a-f95f-4da5-8895-b7ee370e5c7c", "/Images/3667240a-f95f-4da5-8895-b7ee370e5c7c.jpg", null, 18, "https://cdna.pcpartpicker.com/static/forever/images/product/e8d573bd2eac864d427645f0d2f7cad8.1600.jpg" },
                    { "3850f95a-562f-4bb8-af27-f937ef1cd13a", "/Images/3850f95a-562f-4bb8-af27-f937ef1cd13a.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/4975cf5b81bf9bc7cc08445417c0e0ed.1600.jpg" },
                    { "3b88db86-67e1-4aac-9e39-0d765a554949", "/Images/3b88db86-67e1-4aac-9e39-0d765a554949.jpg", null, 27, "https://cdna.pcpartpicker.com/static/forever/images/product/c4dd55a69469ec64be1f6a69864dc7e6.1600.jpg" },
                    { "41f8ee04-f97f-41d8-8cba-18ad9dd01217", "/Images/41f8ee04-f97f-41d8-8cba-18ad9dd01217.jpg", null, 12, "https://cdna.pcpartpicker.com/static/forever/images/product/4ff70faff6636170612b985373f74d1e.1600.jpg" },
                    { "42d1ebb0-6b86-4b09-ad4f-4f34c189b01c", "/Images/42d1ebb0-6b86-4b09-ad4f-4f34c189b01c.jpg", null, 41, "https://cdna.pcpartpicker.com/static/forever/images/product/1411d2ffe69ca84f0c740ee5d0df4a0e.1600.jpg" },
                    { "42fb9716-1e61-4e4f-ae83-e8043b6c9ba0", "/Images/42fb9716-1e61-4e4f-ae83-e8043b6c9ba0.jpg", null, 3, "https://cdna.pcpartpicker.com/static/forever/images/product/3ef757133d38ac40afe75da691ba7d60.1600.jpg" },
                    { "4369891f-6ffc-4227-b3f2-4ec660ea74b9", "/Images/4369891f-6ffc-4227-b3f2-4ec660ea74b9.jpg", null, 40, "https://cdna.pcpartpicker.com/static/forever/images/product/acaf1664d5bee7d6eaca0eeab94a3aff.1600.jpg" },
                    { "4588eab1-c87c-4661-9ddc-8d9c9de8c4b8", "/Images/4588eab1-c87c-4661-9ddc-8d9c9de8c4b8.jpg", null, 25, "https://cdna.pcpartpicker.com/static/forever/images/product/9f7b45a2816c45ea9449e8ca2bf6f616.1600.jpg" },
                    { "490f8038-9bad-4180-a0d2-39e9e9f6292f", "/Images/490f8038-9bad-4180-a0d2-39e9e9f6292f.jpg", null, 39, "https://cdna.pcpartpicker.com/static/forever/images/product/1feb55de02c0b18beceb45600ab4882a.1600.jpg" },
                    { "49eb0ef2-158b-4d65-a292-1c133a777621", "/Images/49eb0ef2-158b-4d65-a292-1c133a777621.jpg", null, 33, "https://cdna.pcpartpicker.com/static/forever/images/product/9f19b59f2318bfd557d22b4ea9dec097.1600.jpg" },
                    { "4a338c8d-2537-4766-8c67-f4446ff478f2", "/Images/4a338c8d-2537-4766-8c67-f4446ff478f2.jpg", null, 34, "https://cdna.pcpartpicker.com/static/forever/images/product/0512d4822aa3bd78639eda0c0cc202ad.1600.jpg" },
                    { "4f9f15d2-126e-4ac9-9cea-1fe8b9e86f97", "/Images/4f9f15d2-126e-4ac9-9cea-1fe8b9e86f97.jpg", null, 44, "https://cdna.pcpartpicker.com/static/forever/images/product/d662cc7b90e3fd45502f7c77d9b54269.1600.jpg" },
                    { "503a5bdb-be29-4da5-9440-5022c33f36ac", "/Images/503a5bdb-be29-4da5-9440-5022c33f36ac.jpg", null, 57, "https://cdna.pcpartpicker.com/static/forever/images/product/9a20036a42989c40ac4815feccc3c380.1600.jpg" },
                    { "50ec92b2-38ee-4b77-a52c-7cbab6b3f7ac", "/Images/50ec92b2-38ee-4b77-a52c-7cbab6b3f7ac.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/4ab5f30ba2f7e3bc8429eff823900b66.1600.jpg" },
                    { "51de09d5-30ae-45d1-ba22-0000251ca087", "/Images/51de09d5-30ae-45d1-ba22-0000251ca087.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/1538883177a83e33b087e056745d95d2.1600.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FilePath", "MainImage", "ProductId", "Url" },
                values: new object[,]
                {
                    { "5267ec91-ad23-4a73-9fde-20271907e089", "/Images/5267ec91-ad23-4a73-9fde-20271907e089.jpg", null, 53, "https://m.media-amazon.com/images/I/31SVEFibvEL.jpg" },
                    { "5366937c-e4fd-4147-b88b-d42cdc5a214a", "/Images/5366937c-e4fd-4147-b88b-d42cdc5a214a.jpg", null, 46, "https://cdna.pcpartpicker.com/static/forever/images/product/31ad0dccffff39f176c038672c8fb2cd.1600.jpg" },
                    { "5474f429-2dc7-40ec-9af1-7a81c24db43f", "/Images/5474f429-2dc7-40ec-9af1-7a81c24db43f.jpg", null, 49, "https://cdna.pcpartpicker.com/static/forever/images/product/a404c6eeceb711738df49595a0ac7d4c.1600.jpg" },
                    { "54bbd9b8-16f4-41a5-895a-2395549fb8ca", "/Images/54bbd9b8-16f4-41a5-895a-2395549fb8ca.jpg", null, 51, "https://cdna.pcpartpicker.com/static/forever/images/product/1643f73c0a44e536665cc5a9470393c9.1600.jpg" },
                    { "574ed2e4-cdec-4133-a588-5241c263f6b8", "/Images/574ed2e4-cdec-4133-a588-5241c263f6b8.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/6859ee3cce2b38b9136206073f9e76da.1600.jpg" },
                    { "589ede3e-390d-4395-9bf3-799bfaf06701", "/Images/589ede3e-390d-4395-9bf3-799bfaf06701.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/14e788b7ea0fa13b2129be9c7baecdbb.1600.jpg" },
                    { "5c73024d-d613-4fae-9873-0e88ff7289c8", "/Images/5c73024d-d613-4fae-9873-0e88ff7289c8.jpg", null, 39, "https://cdna.pcpartpicker.com/static/forever/images/product/c27c50cf8e875c9152bde42bf6c540e6.1600.jpg" },
                    { "5d956bf3-d052-44bf-ae8f-29e945da2bb9", "/Images/5d956bf3-d052-44bf-ae8f-29e945da2bb9.jpg", null, 54, "https://cdna.pcpartpicker.com/static/forever/images/product/c1cef36415ba8f85086b55459b9bf0aa.1600.jpg" },
                    { "5f206e19-dea7-4c40-91e7-852458e61831", "/Images/5f206e19-dea7-4c40-91e7-852458e61831.jpg", null, 43, "https://m.media-amazon.com/images/I/4189N8RLVYL.jpg" },
                    { "616f99ab-d19f-43cb-9743-f62376b7cd10", "/Images/616f99ab-d19f-43cb-9743-f62376b7cd10.jpg", null, 15, "https://cdna.pcpartpicker.com/static/forever/images/product/fee3ba4d684ea643cc72a1c38f0dbc2f.1600.jpg" },
                    { "6625b408-607b-48d2-91d8-356ba3e684dd", "/Images/6625b408-607b-48d2-91d8-356ba3e684dd.jpg", null, 31, "https://m.media-amazon.com/images/I/41qGXVVM++L.jpg" },
                    { "66986a8c-76fb-4626-a2b7-93b4d4aae61f", "/Images/66986a8c-76fb-4626-a2b7-93b4d4aae61f.jpg", null, 34, "https://cdna.pcpartpicker.com/static/forever/images/product/d7a5742ff148519dc3960487b4ee8c3b.1600.jpg" },
                    { "66d9eb05-c031-4e76-bb69-0c650657ff94", "/Images/66d9eb05-c031-4e76-bb69-0c650657ff94.jpg", null, 42, "https://cdna.pcpartpicker.com/static/forever/images/product/72afebab92f6ad28ba42d28c64442a07.1600.jpg" },
                    { "71db4dae-fa71-4311-84b5-ea7b29fcf5fa", "/Images/71db4dae-fa71-4311-84b5-ea7b29fcf5fa.jpg", null, 36, "https://cdna.pcpartpicker.com/static/forever/images/product/6bfd83b70242125dd19a098b04deb9e1.1600.jpg" },
                    { "729cfb1b-62fd-4a7f-a11c-b073bd0d8969", "/Images/729cfb1b-62fd-4a7f-a11c-b073bd0d8969.jpg", null, 49, "https://cdna.pcpartpicker.com/static/forever/images/product/73abc535b47971b36868e797a4c4c96f.1600.jpg" },
                    { "7580baab-5081-45a2-b227-787ab2263775", "/Images/7580baab-5081-45a2-b227-787ab2263775.jpg", null, 6, "https://cdna.pcpartpicker.com/static/forever/images/product/9a001de1081123932309b918dab89b01.1600.jpg" },
                    { "76f054da-5ffc-4fe3-aa6b-8d6743cf83a9", "/Images/76f054da-5ffc-4fe3-aa6b-8d6743cf83a9.jpg", null, 10, "https://cdna.pcpartpicker.com/static/forever/images/product/12bfecb3325a384ef35e38ada6b8bca3.1600.jpg" },
                    { "77eaf7c6-e81d-4338-be23-a6d84ceb04ca", "/Images/77eaf7c6-e81d-4338-be23-a6d84ceb04ca.jpg", null, 11, "https://cdna.pcpartpicker.com/static/forever/images/product/cbc52effd345bd5e9d66b5f7d198f8b4.1600.jpg" },
                    { "7a8ba6fe-03d7-485e-b3af-8cdeec70d067", "/Images/7a8ba6fe-03d7-485e-b3af-8cdeec70d067.jpg", null, 32, "https://cdna.pcpartpicker.com/static/forever/images/product/0caced7ab126d5fe057d6ce2306cee39.1600.jpg" },
                    { "7d963661-04f6-43ae-a1e8-f314b597627d", "/Images/7d963661-04f6-43ae-a1e8-f314b597627d.jpg", null, 34, "https://cdna.pcpartpicker.com/static/forever/images/product/dd92e303301f8c06036a17d24ed9ab46.1600.jpg" },
                    { "824fc1f4-6e52-4776-9ca5-e42e54e68e69", "/Images/824fc1f4-6e52-4776-9ca5-e42e54e68e69.jpg", null, 26, "https://cdna.pcpartpicker.com/static/forever/images/product/24f2250843caa631f82d234bc781e9d0.1600.jpg" },
                    { "83f98923-0661-44ee-b1aa-be4411619690", "/Images/83f98923-0661-44ee-b1aa-be4411619690.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/0d8a58e3c4bf5ecde38ed4f9738c91fd.1600.jpg" },
                    { "852824a2-c4bd-4582-8f74-9e02667cd57a", "/Images/852824a2-c4bd-4582-8f74-9e02667cd57a.jpg", null, 37, "https://cdna.pcpartpicker.com/static/forever/images/product/c4927b86acf31ab403449e81673d56f7.1600.jpg" },
                    { "85a78cf1-d5af-4363-a2a2-13837485f50f", "/Images/85a78cf1-d5af-4363-a2a2-13837485f50f.jpg", null, 31, "https://m.media-amazon.com/images/I/41bmeAiECpL.jpg" },
                    { "868302ff-1931-4b03-9afe-9c3c321dcb3b", "/Images/868302ff-1931-4b03-9afe-9c3c321dcb3b.jpg", null, 23, "https://cdna.pcpartpicker.com/static/forever/images/product/dbc81b89efc82ce66fb2e3ab7e0f0658.1600.jpg" },
                    { "8982521c-bcd4-4ee4-a712-6085d687e588", "/Images/8982521c-bcd4-4ee4-a712-6085d687e588.jpg", null, 49, "https://cdna.pcpartpicker.com/static/forever/images/product/2981675c06bdccf5daa39fe5c567c5f4.1600.jpg" },
                    { "8ca5997f-53fe-4bf4-8af9-e95994dbb61d", "/Images/8ca5997f-53fe-4bf4-8af9-e95994dbb61d.jpg", null, 31, "https://m.media-amazon.com/images/I/418Ezw9+M5L.jpg" },
                    { "8f833fa0-8648-4f0c-bd2f-914fa872ff6a", "/Images/8f833fa0-8648-4f0c-bd2f-914fa872ff6a.jpg", null, 47, "https://cdna.pcpartpicker.com/static/forever/images/product/044e21f178b0ad10f69fbc76b6ac013e.1600.jpg" },
                    { "8fd47fe2-a487-4fce-9c1b-427de0af5d9e", "/Images/8fd47fe2-a487-4fce-9c1b-427de0af5d9e.jpg", null, 8, "https://cdna.pcpartpicker.com/static/forever/images/product/5b6a5e7f4cf456ccf6415235cf7adc99.1600.jpg" },
                    { "91cd8cd7-0b1f-4ad7-a9e2-efe029133c78", "/Images/91cd8cd7-0b1f-4ad7-a9e2-efe029133c78.jpg", null, 45, "https://cdna.pcpartpicker.com/static/forever/images/product/ee20df28356c1f66b8d3c6d69be9f823.1600.jpg" },
                    { "926a0cc9-f77f-4d38-a4ed-80954038182b", "/Images/926a0cc9-f77f-4d38-a4ed-80954038182b.jpg", null, 27, "https://cdna.pcpartpicker.com/static/forever/images/product/177c70bda04558a33afef3fa7fbf6d3a.1600.jpg" },
                    { "92dd4206-5009-4274-9340-41d101a666ef", "/Images/92dd4206-5009-4274-9340-41d101a666ef.jpg", null, 54, "https://m.media-amazon.com/images/I/31Ey7sbAF-L.jpg" },
                    { "94be617b-2886-4796-a816-e70d8254db5c", "/Images/94be617b-2886-4796-a816-e70d8254db5c.jpg", null, 36, "https://cdna.pcpartpicker.com/static/forever/images/product/eac8b9bc26c9fc82da9099dd785b0d25.1600.jpg" },
                    { "9650da52-cfd0-4da3-a484-8b5d47b896a0", "/Images/9650da52-cfd0-4da3-a484-8b5d47b896a0.jpg", null, 23, "https://cdna.pcpartpicker.com/static/forever/images/product/c740684e2cd2339bf845f7493711bcb7.1600.jpg" },
                    { "984fdc6b-11f3-4b24-ab69-6f4eb853d722", "/Images/984fdc6b-11f3-4b24-ab69-6f4eb853d722.jpg", null, 27, "https://cdna.pcpartpicker.com/static/forever/images/product/786ae500dc9ee10793a78a066bfdc2ae.1600.jpg" },
                    { "988610ab-3fdb-46b8-883a-511e709c51f9", "/Images/988610ab-3fdb-46b8-883a-511e709c51f9.jpg", null, 30, "https://m.media-amazon.com/images/I/41OrNb0Me-L.jpg" },
                    { "997a8f8f-9e44-4925-b898-ace5cd35bfcd", "/Images/997a8f8f-9e44-4925-b898-ace5cd35bfcd.jpg", null, 20, "https://cdna.pcpartpicker.com/static/forever/images/product/c7b5b7dacbecdcdd0e073b761193eef6.1600.jpg" },
                    { "9a4f1cef-e773-4b24-9f8c-c4359001b1dd", "/Images/9a4f1cef-e773-4b24-9f8c-c4359001b1dd.jpg", null, 34, "https://cdna.pcpartpicker.com/static/forever/images/product/53592fbfc2434075c871babe2ebd9b4d.1600.jpg" },
                    { "9aede4aa-7c74-44d1-a70b-201b79442096", "/Images/9aede4aa-7c74-44d1-a70b-201b79442096.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/e01b4d44c0de80c58cefbcc78a1fe809.1600.jpg" },
                    { "a10bdd3e-a845-4cb4-9079-0ec9729cd2ff", "/Images/a10bdd3e-a845-4cb4-9079-0ec9729cd2ff.jpg", null, 28, "https://cdna.pcpartpicker.com/static/forever/images/product/56f77032e78c9af99041786b5196fe91.1600.jpg" },
                    { "a1554699-e1bf-44d6-83d1-c9196b545703", "/Images/a1554699-e1bf-44d6-83d1-c9196b545703.jpg", null, 31, "https://cdna.pcpartpicker.com/static/forever/images/product/eacaf9e3a9f012060fbd0a98f4e22511.1600.jpg" },
                    { "a2b37b1f-827f-4ffd-ad2a-6a4a5ecdd938", "/Images/a2b37b1f-827f-4ffd-ad2a-6a4a5ecdd938.jpg", null, 29, "https://cdna.pcpartpicker.com/static/forever/images/product/304c409dc991a5bc733316ceac29f77e.1600.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FilePath", "MainImage", "ProductId", "Url" },
                values: new object[,]
                {
                    { "a326c01d-f7b2-4f67-9a5d-4944f8960f10", "/Images/a326c01d-f7b2-4f67-9a5d-4944f8960f10.jpg", null, 19, "https://cdna.pcpartpicker.com/static/forever/images/product/3b2a91588d1a28bfa1b0184fb7f1c0a1.1600.jpg" },
                    { "a5afb091-9e09-4a84-9f58-e14d3685e1e7", "/Images/a5afb091-9e09-4a84-9f58-e14d3685e1e7.jpg", null, 31, "https://m.media-amazon.com/images/I/31ZDKNuuZ8L.jpg" },
                    { "a6089e18-0213-4564-a0a1-c3923cc9466f", "/Images/a6089e18-0213-4564-a0a1-c3923cc9466f.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/fffd31cf56d1bec77ca7f6d1bebdb4ef.1600.jpg" },
                    { "a6cb50fc-d720-438f-b2fb-b2abf73ad1d0", "/Images/a6cb50fc-d720-438f-b2fb-b2abf73ad1d0.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/4d9006e40c0471daaf7d1982f32aa5ed.1600.jpg" },
                    { "a8b7d89b-08eb-485f-9059-03fe91ee36d2", "/Images/a8b7d89b-08eb-485f-9059-03fe91ee36d2.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/3215b6dc5bfe17dc7f2f99071713d74b.1600.jpg" },
                    { "aa8c05b7-c942-4397-8a17-029c0d8dc875", "/Images/aa8c05b7-c942-4397-8a17-029c0d8dc875.jpg", null, 46, "https://cdna.pcpartpicker.com/static/forever/images/product/ae6e2d9188a5b8d2452c008cbbdfb6c2.1600.jpg" },
                    { "aba175f1-63c2-4725-ae4b-740eecac6bf0", "/Images/aba175f1-63c2-4725-ae4b-740eecac6bf0.jpg", null, 44, "https://cdna.pcpartpicker.com/static/forever/images/product/64bf868b636fe7f3a847f59c1a0f146b.1600.jpg" },
                    { "abc2b28b-f750-45c4-9ebc-fd8d427a397a", "/Images/abc2b28b-f750-45c4-9ebc-fd8d427a397a.jpg", null, 53, "https://m.media-amazon.com/images/I/31Z-DhEv-NL.jpg" },
                    { "ac9c897f-0834-4041-b87b-0f3918f6df24", "/Images/ac9c897f-0834-4041-b87b-0f3918f6df24.jpg", null, 32, "https://cdna.pcpartpicker.com/static/forever/images/product/84cb77175187296029f50f8bf6ca6960.1600.jpg" },
                    { "af776ffc-d3ce-4313-b19d-dcb2a0a09cd4", "/Images/af776ffc-d3ce-4313-b19d-dcb2a0a09cd4.jpg", null, 50, "https://m.media-amazon.com/images/I/21yyXF0cW4L.jpg" },
                    { "b17cdfaf-7c31-4b18-adc9-0dec44672b09", "/Images/b17cdfaf-7c31-4b18-adc9-0dec44672b09.jpg", null, 12, "https://cdna.pcpartpicker.com/static/forever/images/product/ca2d72ee76257a0397e4b4fc1056d60d.1600.jpg" },
                    { "b2eb45be-70f3-498e-91d5-e43f7861b47b", "/Images/b2eb45be-70f3-498e-91d5-e43f7861b47b.jpg", null, 39, "https://cdna.pcpartpicker.com/static/forever/images/product/7134ada8090eab583a9cdbafdccf3f9a.1600.jpg" },
                    { "b4f70f16-4962-4adb-aa21-cbaae0e369bb", "/Images/b4f70f16-4962-4adb-aa21-cbaae0e369bb.jpg", null, 55, "https://cdna.pcpartpicker.com/static/forever/images/product/814013acd24de0801b6a32a2bd3c6fa3.1600.jpg" },
                    { "b5541707-2e00-45fc-9221-3f940ee50255", "/Images/b5541707-2e00-45fc-9221-3f940ee50255.jpg", null, 6, "https://cdna.pcpartpicker.com/static/forever/images/product/9b4cefb2e43f2c358f3a97a31e1be90b.1600.jpg" },
                    { "b69dab00-2857-4555-8d7b-7ae6db195795", "/Images/b69dab00-2857-4555-8d7b-7ae6db195795.jpg", null, 17, "https://cdna.pcpartpicker.com/static/forever/images/product/5f09867b54e9ad932b4dd1bc767f6238.1600.jpg" },
                    { "bb1cefec-0b96-494e-915c-430b17063192", "/Images/bb1cefec-0b96-494e-915c-430b17063192.jpg", null, 48, "https://m.media-amazon.com/images/I/41tnErFDq3L.jpg" },
                    { "bd8bb8e7-1221-466e-8be8-1faaa623f3b4", "/Images/bd8bb8e7-1221-466e-8be8-1faaa623f3b4.jpg", null, 21, "https://cdna.pcpartpicker.com/static/forever/images/product/97e2bd828644767c8a80b71f8cb14743.1600.jpg" },
                    { "be653ffe-93b8-4eeb-a9d3-7c7e8c27ca95", "/Images/be653ffe-93b8-4eeb-a9d3-7c7e8c27ca95.jpg", null, 53, "https://m.media-amazon.com/images/I/41ZM7pNwiJL.jpg" },
                    { "c649c783-fd90-40f1-b15e-1703623ddc8a", "/Images/c649c783-fd90-40f1-b15e-1703623ddc8a.jpg", null, 54, "https://m.media-amazon.com/images/I/31lbKfslw-L.jpg" },
                    { "cc4db4c9-b014-4fa4-891a-85051ad2a631", "/Images/cc4db4c9-b014-4fa4-891a-85051ad2a631.jpg", null, 38, "https://cdna.pcpartpicker.com/static/forever/images/product/590df3876fa2f75521f718e26036d99e.1600.jpg" },
                    { "cc98fedc-1307-4f2c-a830-c7cb312c9a07", "/Images/cc98fedc-1307-4f2c-a830-c7cb312c9a07.jpg", null, 31, "https://m.media-amazon.com/images/I/41B-bypM5FL.jpg" },
                    { "cd1621e2-52d4-4190-9b14-70568d0ca2ed", "/Images/cd1621e2-52d4-4190-9b14-70568d0ca2ed.jpg", null, 44, "https://cdna.pcpartpicker.com/static/forever/images/product/9329a601afeadc9f218b235fd02778c7.1600.jpg" },
                    { "cf221477-6c55-4318-8674-ee8a8f02f370", "/Images/cf221477-6c55-4318-8674-ee8a8f02f370.jpg", null, 26, "https://cdna.pcpartpicker.com/static/forever/images/product/4f3b20c2caf70107a2c3735d9e165015.1600.jpg" },
                    { "cfcf1476-2863-4fe6-a892-8ffb8975b166", "/Images/cfcf1476-2863-4fe6-a892-8ffb8975b166.jpg", null, 31, "https://m.media-amazon.com/images/I/31r8KD7+2BL.jpg" },
                    { "cfe3ca17-7d35-4897-95a1-22fae8071309", "/Images/cfe3ca17-7d35-4897-95a1-22fae8071309.jpg", null, 29, "https://cdna.pcpartpicker.com/static/forever/images/product/69c7679bbfccb706c80f41b452d36f54.1600.jpg" },
                    { "d239df37-50c8-4e9b-a80d-04a1e6a8670a", "/Images/d239df37-50c8-4e9b-a80d-04a1e6a8670a.jpg", null, 12, "https://cdna.pcpartpicker.com/static/forever/images/product/7e96ffff509386a74534bbe0dafc2a6e.1600.jpg" },
                    { "d353dbeb-9820-41b0-8e0b-8f3bf1fca1f5", "/Images/d353dbeb-9820-41b0-8e0b-8f3bf1fca1f5.jpg", null, 16, "https://m.media-amazon.com/images/I/41jJSPS8W7L.jpg" },
                    { "d3617f44-7666-4563-82c0-d54aa838a954", "/Images/d3617f44-7666-4563-82c0-d54aa838a954.jpg", null, 58, "https://cdna.pcpartpicker.com/static/forever/images/product/51cdef3b9216df555b7c7eec7620b0e7.1600.jpg" },
                    { "d41da59e-ee18-44d2-8304-87a056c76767", "/Images/d41da59e-ee18-44d2-8304-87a056c76767.jpg", null, 38, "https://cdna.pcpartpicker.com/static/forever/images/product/45ba4975d9641058c4284b7766939591.1600.jpg" },
                    { "d42d3600-ac00-4976-bb49-681f9d7c4e27", "/Images/d42d3600-ac00-4976-bb49-681f9d7c4e27.jpg", null, 5, "https://cdna.pcpartpicker.com/static/forever/images/product/2f3405387f23ab827695d966ea9f9682.1600.jpg" },
                    { "d4ed8af0-c378-490c-bab2-09a95686808a", "/Images/d4ed8af0-c378-490c-bab2-09a95686808a.jpg", null, 34, "https://cdna.pcpartpicker.com/static/forever/images/product/beccd007e2d3672aa3772619d54fd5dd.1600.jpg" },
                    { "d4fda4f4-b48f-4da5-a6c9-693a3e3ef73b", "/Images/d4fda4f4-b48f-4da5-a6c9-693a3e3ef73b.jpg", null, 43, "https://cdna.pcpartpicker.com/static/forever/images/product/125c1da538a8704be799ef12a506e177.1600.jpg" },
                    { "d767d6bb-e3ab-4fa4-9398-9003de15cc00", "/Images/d767d6bb-e3ab-4fa4-9398-9003de15cc00.jpg", null, 33, "https://cdna.pcpartpicker.com/static/forever/images/product/ea0dee3c3376cc6326ca2f4a73a054ac.1600.jpg" },
                    { "da97a2e9-d13e-4c08-bc7b-883c8d492f86", "/Images/da97a2e9-d13e-4c08-bc7b-883c8d492f86.jpg", null, 14, "https://cdna.pcpartpicker.com/static/forever/images/product/ba20600286bf8f74ce71df37ed8aef65.1600.jpg" },
                    { "de272047-1790-4f5f-bc74-a79ffb720335", "/Images/de272047-1790-4f5f-bc74-a79ffb720335.jpg", null, 39, "https://cdna.pcpartpicker.com/static/forever/images/product/589124c889203fda89e25b99964ee3cb.1600.jpg" },
                    { "e0884d7b-45f0-4484-b72f-4ca35db6936f", "/Images/e0884d7b-45f0-4484-b72f-4ca35db6936f.jpg", null, 35, "https://cdna.pcpartpicker.com/static/forever/images/product/72a586f112591cd7b43f4b0dc244ba29.1600.jpg" },
                    { "e0b29485-265a-4f85-a3db-1a65df513ae8", "/Images/e0b29485-265a-4f85-a3db-1a65df513ae8.jpg", null, 57, "https://cdna.pcpartpicker.com/static/forever/images/product/4553483e1ab3289f1b7e0482bc3da223.1600.jpg" },
                    { "eb201225-6593-409b-955b-58603556f34b", "/Images/eb201225-6593-409b-955b-58603556f34b.jpg", null, 12, "https://cdna.pcpartpicker.com/static/forever/images/product/322a6059c413dd736536e5ad5c3a2285.1600.jpg" },
                    { "eb5bad8b-889a-4ebd-9966-145e4f787368", "/Images/eb5bad8b-889a-4ebd-9966-145e4f787368.jpg", null, 34, "https://cdna.pcpartpicker.com/static/forever/images/product/1977a3a3f6f1238d12ea2a555be4d7ce.1600.jpg" },
                    { "ec07baac-38f2-4d85-b278-7e1c2ed6ece5", "/Images/ec07baac-38f2-4d85-b278-7e1c2ed6ece5.jpg", null, 9, "https://cdna.pcpartpicker.com/static/forever/images/product/8ab57dc3c0eb346c72ef7a2405e31227.1600.jpg" },
                    { "ec2ac398-5973-4594-a155-e53d3f6b1b1d", "/Images/ec2ac398-5973-4594-a155-e53d3f6b1b1d.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/5909bba6badf1236eb5c127aa97091c7.1600.jpg" },
                    { "ed1a380d-d279-427e-89a0-91e9fb56167d", "/Images/ed1a380d-d279-427e-89a0-91e9fb56167d.jpg", null, 39, "https://cdna.pcpartpicker.com/static/forever/images/product/108a73ebe0ccd2107410f6602134b39f.1600.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FilePath", "MainImage", "ProductId", "Url" },
                values: new object[,]
                {
                    { "edc756ff-7dec-42c0-8fd6-d6baeeff938f", "/Images/edc756ff-7dec-42c0-8fd6-d6baeeff938f.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/7b0dd4af0da38d3d1bfe7b06dba06907.1600.jpg" },
                    { "f0eff95f-91ff-4f96-b703-2576a8ab50b5", "/Images/f0eff95f-91ff-4f96-b703-2576a8ab50b5.jpg", null, 44, "https://cdna.pcpartpicker.com/static/forever/images/product/c5c7e572704d69ffbd70e0043ea0fbba.1600.jpg" },
                    { "f19aaa80-4cdd-443a-a542-8eeb1320998c", "/Images/f19aaa80-4cdd-443a-a542-8eeb1320998c.jpg", null, 33, "https://cdna.pcpartpicker.com/static/forever/images/product/e16f356c568cce4de8b945232f49c676.1600.jpg" },
                    { "f4c93663-203a-45bf-ae7c-e76ab78dd290", "/Images/f4c93663-203a-45bf-ae7c-e76ab78dd290.jpg", null, 30, "https://m.media-amazon.com/images/I/3119BHzm7NL.jpg" },
                    { "f68fdafc-f5db-4ab7-94ae-81a09e4f817c", "/Images/f68fdafc-f5db-4ab7-94ae-81a09e4f817c.jpg", null, 12, "https://cdna.pcpartpicker.com/static/forever/images/product/85b8dbb810453334ae54f9744a082801.1600.jpg" },
                    { "f741bca7-e0b3-414d-bdcd-40c0c9ff3cdd", "/Images/f741bca7-e0b3-414d-bdcd-40c0c9ff3cdd.jpg", null, 39, "https://cdna.pcpartpicker.com/static/forever/images/product/86b45d138eeeb6df121fd3fee4ba6ec2.1600.jpg" },
                    { "f981971f-a887-43ca-b3e2-4f39f613483d", "/Images/f981971f-a887-43ca-b3e2-4f39f613483d.jpg", null, 7, "https://cdna.pcpartpicker.com/static/forever/images/product/b45763abe7a0517129d3c0e026d0370d.1600.jpg" },
                    { "f98b5387-e029-4ab9-8366-f764b5313e4c", "/Images/f98b5387-e029-4ab9-8366-f764b5313e4c.jpg", null, 33, "https://cdna.pcpartpicker.com/static/forever/images/product/45f130618c6312f8e0563fe324783fb8.1600.jpg" },
                    { "fad4f25c-7bb3-4a17-ba18-c9b2969e8852", "/Images/fad4f25c-7bb3-4a17-ba18-c9b2969e8852.jpg", null, 27, "https://cdna.pcpartpicker.com/static/forever/images/product/336c7955df0312d04655dd3a13973c95.1600.jpg" },
                    { "fcf45d3e-bd42-4e4f-90ce-d37b26f58995", "/Images/fcf45d3e-bd42-4e4f-90ce-d37b26f58995.jpg", null, 32, "https://cdna.pcpartpicker.com/static/forever/images/product/8fea66429634183b78ae8cf477e6f7fa.1600.jpg" },
                    { "fd700b5d-ae2f-4dae-91ae-46d8f3bf3be2", "/Images/fd700b5d-ae2f-4dae-91ae-46d8f3bf3be2.jpg", null, 34, "https://cdna.pcpartpicker.com/static/forever/images/product/760d63945cda200b5c35cb492ebc5a25.1600.jpg" },
                    { "fe1a4e59-6541-4d42-ad4a-90094c4b8c97", "/Images/fe1a4e59-6541-4d42-ad4a-90094c4b8c97.jpg", null, 54, "https://m.media-amazon.com/images/I/31WTkBtfx-L.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PartNumbers",
                columns: new[] { "Id", "Number", "ProductId" },
                values: new object[,]
                {
                    { 1, "100-100000065BOX", 3 },
                    { 2, "100-100000910WOF", 4 },
                    { 3, "BX8071513700K", 5 },
                    { 4, "i7-13700K", 5 },
                    { 5, "100-100000063WOF", 6 },
                    { 6, "RR-212S-20PK-R2", 7 },
                    { 7, "MLW-D24M-A18PC-R2", 8 },
                    { 8, "BK022", 9 },
                    { 9, "CW-9060070-WW", 10 },
                    { 10, "B550 GAMING GEN3", 11 },
                    { 11, "7B86-050R", 11 },
                    { 12, "911-7B86-050", 11 },
                    { 13, "B650 AORUS ELITE AX", 12 },
                    { 14, "MAG B550 TOMAHAWK", 13 },
                    { 15, "7C91-001R", 13 },
                    { 16, "B550TMHWK", 13 },
                    { 17, "Z790 AORUS ELITE AX", 14 },
                    { 18, "CMK16GX4M2B3200C16", 15 },
                    { 19, "CMK32GX5M2B5600C36", 16 },
                    { 20, "CMW32GX4M2Z3600C18", 17 },
                    { 21, "F5-6000J3636F16GX2-TZ5RK", 18 },
                    { 22, "MZ-V8P2T0B/AM", 19 },
                    { 23, "MZ-V8P2T0BW", 19 },
                    { 24, "ST2000DM008", 20 },
                    { 25, "SA400S37/240G", 21 },
                    { 26, "CT4000P3SSD8", 22 },
                    { 27, "RTX3060Ventus2X12GOC", 23 },
                    { 28, "GeForce RTX 3060 VENTUS 2X 12G OC", 23 },
                    { 29, "V397-022R", 23 },
                    { 30, "912-V397-039", 23 }
                });

            migrationBuilder.InsertData(
                table: "PartNumbers",
                columns: new[] { "Id", "Number", "ProductId" },
                values: new object[,]
                {
                    { 31, "GV-N4070WF3OC-12GD", 24 },
                    { 32, "ROG-STRIX-RTX4090-O24G-GAMING", 25 },
                    { 33, "90YV0ID0-M0NA00", 25 },
                    { 34, "90YV0ID0-M0AA00", 25 },
                    { 35, "RTX3060Ventus3X12GOC", 26 },
                    { 36, "GeForce RTX 3060 VENTUS 3X 12G OC", 26 },
                    { 37, "V397-031R", 26 },
                    { 38, "G3060V3X12C", 26 },
                    { 39, "912-V397-038", 26 },
                    { 40, "CP-9020262-NA", 27 },
                    { 41, "CP-9020262-UK", 27 },
                    { 42, "CP-9020262-EU", 27 },
                    { 43, "CP-9020262-AU", 27 },
                    { 44, "PS-TPD-0600NNFAGU-2", 28 },
                    { 45, "MPG A650GF", 29 },
                    { 46, "306-7ZP0A11-CE0", 29 },
                    { 47, "100-W1-0500-KR", 30 },
                    { 48, "100-W1-0500-K2", 30 },
                    { 49, "100-W1-0500-K3", 30 },
                    { 50, "R-CC560-BKGAA4-G-1", 31 },
                    { 51, "CC-H51FB-01", 32 },
                    { 52, "PC-O11DEW", 33 },
                    { 53, "O11DEW", 33 },
                    { 54, "FD-C-NOR1C-02", 34 },
                    { 55, "KHX-HSCP-RD", 35 },
                    { 56, "4P5M0AA", 35 },
                    { 57, "RZ04-03240100-R3U1", 36 },
                    { 58, "981-000817", 37 },
                    { 59, "RZ04-02980200-R3M1", 38 },
                    { 60, "RZ04-02980200", 38 },
                    { 61, "CH-910D019-NA", 39 },
                    { 62, "920-002478", 40 },
                    { 63, "920-002479", 40 },
                    { 64, "RZ03-03390300-R3M1", 41 },
                    { 65, "RZ03-03490200-R3U1", 42 },
                    { 66, "910-005469", 43 },
                    { 67, "RZ01-04000100-R3U1", 44 },
                    { 68, "RZ01-03850200-R3U1", 45 },
                    { 69, "RZ01-03850200-R3M1", 45 },
                    { 70, "RZ01-03850200-R3G1", 45 },
                    { 71, "RZ01-03850200-R3A1", 45 },
                    { 72, "RZ01-03250100-R3U1", 46 }
                });

            migrationBuilder.InsertData(
                table: "PartNumbers",
                columns: new[] { "Id", "Number", "ProductId" },
                values: new object[,]
                {
                    { 73, "RZ01-03250100-R3M1", 46 },
                    { 74, "980-000800", 47 },
                    { 75, "980-000810", 47 },
                    { 76, "980-000812", 47 },
                    { 77, "980-000467", 48 },
                    { 78, "RZ05-03920100-R3U1", 49 },
                    { 79, "RZ05-03920100-R3M1", 49 },
                    { 80, "MF8375", 50 },
                    { 81, "960-001105", 51 },
                    { 82, "RZ19-04420100-R3U1", 52 },
                    { 83, "RZ19-04420100-R3M1", 52 },
                    { 84, "VG27AQ", 53 },
                    { 85, "90LM0500-B01370", 53 },
                    { 86, "90LM0500-B03370", 53 },
                    { 87, "LC27G75TQSUXEN", 54 },
                    { 88, "LC27G75TQSNXZA", 54 },
                    { 89, "LC27G75TQSRXEN", 54 },
                    { 90, "C27G2Z", 55 },
                    { 91, "960-000694", 56 },
                    { 92, "RZ19-02320100-R3U1", 57 },
                    { 93, "27GR75Q-B", 58 },
                    { 94, "27GR75Q-B.AEU", 58 }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 9, null, 9, "6" },
                    { 10, null, 10, "3.7 GHz" },
                    { 11, null, 11, "4.6 GHz" },
                    { 12, null, 12, "65 W" },
                    { 13, null, 13, "AMD Ryzen 5" },
                    { 14, null, 14, "Zen 3" },
                    { 15, null, 15, "Vermeer" },
                    { 16, null, 16, "AM4" },
                    { 17, null, 17, "None" },
                    { 18, null, 18, "128 GB" },
                    { 19, null, 19, "No" },
                    { 20, null, 20, "Yes" },
                    { 21, null, 21, "Boxed" },
                    { 22, null, 22, "6 x 32 kB Instruction" },
                    { 23, null, 22, "6 x 32 kB Data" },
                    { 24, null, 23, "6 x 512 kB" },
                    { 25, null, 24, "1 x 32 MB" },
                    { 26, null, 25, "7 nm" },
                    { 27, null, 26, "Yes" },
                    { 28, null, 27, "Yes" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 29, null, 9, "8" },
                    { 30, null, 10, "4.2 GHz" },
                    { 31, null, 11, "5 GHz" },
                    { 32, null, 12, "120 W" },
                    { 33, null, 13, "AMD Ryzen 7" },
                    { 34, null, 14, "Zen 4" },
                    { 35, null, 15, "Raphael" },
                    { 36, null, 16, "AM5" },
                    { 37, null, 17, "Radeon" },
                    { 38, null, 19, "Yes" },
                    { 39, null, 20, "No" },
                    { 40, null, 22, "8 x 32 kB Instruction" },
                    { 41, null, 22, "8 x 32 kB Data" },
                    { 42, null, 23, "8 x 1 MB" },
                    { 43, null, 24, "1 x 96 MB" },
                    { 44, null, 25, "5 nm" },
                    { 45, null, 26, "No" },
                    { 46, null, 9, "16" },
                    { 47, null, 10, "3.4 GHz" },
                    { 48, null, 11, "5.4 GHz" },
                    { 49, null, 12, "125 W" },
                    { 50, null, 13, "Intel Core i7" },
                    { 51, null, 14, "Raptor Lake" },
                    { 52, null, 15, "Raptor Lake" },
                    { 53, null, 16, "LGA1700" },
                    { 54, null, 17, "Intel UHD Graphics 770" },
                    { 55, null, 18, "192 GB" },
                    { 56, null, 22, "8 x 48 kB Data" },
                    { 57, null, 23, "8 x 2 MB" },
                    { 58, null, 24, "1 x 30 MB" },
                    { 59, null, 25, "10 nm" },
                    { 60, null, 27, "Yes: Hyper-Threading" },
                    { 61, null, 28, "8 x 32 kB Instruction" },
                    { 62, null, 28, "8 x 64 kB Data" },
                    { 63, null, 29, "2 x 4 MB" },
                    { 64, null, 10, "3.8 GHz" },
                    { 65, null, 11, "4.7 GHz" },
                    { 66, null, 12, "105 W" },
                    { 67, null, 23, "8 x 512 kB" },
                    { 68, null, 30, "Hyper 212 Black Edition" },
                    { 69, null, 31, "800 - 2000 RPM" },
                    { 70, null, 32, "6.5 - 26 dB" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 71, null, 33, "159 mm" },
                    { 72, null, 34, "No" },
                    { 73, null, 35, "No" },
                    { 74, null, 36, "AM2" },
                    { 75, null, 36, "AM2+" },
                    { 76, null, 36, "AM3" },
                    { 77, null, 36, "AM3+" },
                    { 78, null, 36, "AM4" },
                    { 79, null, 36, "AM5" },
                    { 80, null, 36, "FM1" },
                    { 81, null, 36, "FM2" },
                    { 82, null, 36, "FM2+" },
                    { 83, null, 36, "LGA1150" },
                    { 84, null, 36, "LGA1151" },
                    { 85, null, 36, "LGA1155" },
                    { 86, null, 36, "LGA1156" },
                    { 87, null, 36, "LGA1200" },
                    { 88, null, 36, "LGA1366" },
                    { 89, null, 36, "LGA1700" },
                    { 90, null, 36, "LGA2011" },
                    { 91, null, 36, "LGA2011-3" },
                    { 92, null, 36, "LGA2066" },
                    { 93, null, 30, "MASTERLIQUID ML240L RGB V2" },
                    { 94, null, 31, "650 - 1800 RPM" },
                    { 95, null, 32, "6 - 27 dB" },
                    { 96, null, 34, "Yes - 240 mm" },
                    { 97, null, 37, "Black" },
                    { 98, null, 30, "Dark Rock Pro 4" },
                    { 99, null, 31, "1500 RPM" },
                    { 100, null, 32, "12.8 - 24.3 dB" },
                    { 101, null, 33, "163 mm" },
                    { 102, null, 30, "iCUE H150i ELITE CAPELLIX XT" },
                    { 103, null, 31, "550 - 2100 RPM" },
                    { 104, null, 32, "5 - 34.1 dB" },
                    { 105, null, 34, "Yes - 360 mm" },
                    { 106, null, 36, "sTR4" },
                    { 107, null, 36, "sTRX4" },
                    { 108, null, 38, "AM4" },
                    { 109, null, 39, "ATX" },
                    { 110, null, 40, "AMD B550" },
                    { 111, null, 41, "128 GB" },
                    { 112, null, 42, "DDR4" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 113, null, 43, "4" },
                    { 114, null, 44, "Black" },
                    { 115, null, 45, "CrossFire Capable" },
                    { 116, null, 46, "2" },
                    { 117, null, 47, "0" },
                    { 118, null, 48, "0" },
                    { 119, null, 49, "4" },
                    { 120, null, 50, "0" },
                    { 121, null, 51, "2260/2280/22110 M-key" },
                    { 122, null, 52, "0" },
                    { 123, null, 53, "0" },
                    { 124, null, 54, "0" },
                    { 125, null, 55, "0" },
                    { 126, null, 56, "6" },
                    { 127, null, 57, "1 x 1 Gb/s (Realtek RTL8111H)" },
                    { 128, null, 58, "Depends on CPU" },
                    { 129, null, 59, "2" },
                    { 130, null, 60, "0" },
                    { 131, null, 61, "1" },
                    { 132, null, 62, "0" },
                    { 133, null, 63, "0" },
                    { 134, null, 64, "No" },
                    { 135, null, 65, "None" },
                    { 136, null, 66, "Yes" },
                    { 137, null, 67, "DDR4-1866" },
                    { 138, null, 67, "DDR4-2133" },
                    { 139, null, 67, "DDR4-2400" },
                    { 140, null, 67, "DDR4-2666" },
                    { 141, null, 67, "DDR4-2800" },
                    { 142, null, 67, "DDR4-2933" },
                    { 143, null, 67, "DDR4-3000" },
                    { 144, null, 67, "DDR4-3200" },
                    { 145, null, 67, "DDR4-3466" },
                    { 146, null, 67, "DDR4-3600" },
                    { 147, null, 67, "DDR4-3733" },
                    { 148, null, 67, "DDR4-3866" },
                    { 149, null, 67, "DDR4-4000" },
                    { 150, null, 67, "DDR4-4133" },
                    { 151, null, 67, "DDR4-4266" },
                    { 152, null, 67, "DDR4-4400" },
                    { 153, null, 38, "AM5" },
                    { 154, null, 40, "AMD B650" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 155, null, 41, "192 GB" },
                    { 156, null, 42, "DDR5" },
                    { 157, null, 67, "DDR5-4400" },
                    { 158, null, 67, "DDR5-4800" },
                    { 159, null, 67, "DDR5-5200" },
                    { 160, null, 67, "DDR5-5600" },
                    { 161, null, 67, "DDR5-6000" },
                    { 162, null, 67, "DDR5-6200" },
                    { 163, null, 67, "DDR5-6400" },
                    { 164, null, 67, "DDR5-6600" },
                    { 165, null, 44, "Black / Silver" },
                    { 166, null, 46, "3" },
                    { 167, null, 49, "0" },
                    { 168, null, 51, "2580/25110 M-key X3" },
                    { 169, null, 56, "4" },
                    { 170, null, 57, "1 x 2.5 Gb/s (Realtek)" },
                    { 171, null, 63, "1" },
                    { 172, null, 65, "Wi-Fi 6E" },
                    { 173, null, 49, "2" },
                    { 174, null, 51, "2242/2260/2280/22110 M-key" },
                    { 175, null, 51, "2242/2260/2280 M-key" },
                    { 176, null, 57, "1 x 1 Gb/s" },
                    { 177, null, 57, "1 x 2.5 Gb/s" },
                    { 178, null, 62, "1" },
                    { 179, null, 67, "DDR4-4533" },
                    { 180, null, 67, "DDR4-4600" },
                    { 181, null, 67, "DDR4-4800" },
                    { 182, null, 67, "DDR4-4866" },
                    { 183, null, 38, "LGA1700" },
                    { 184, null, 40, "Intel Z790" },
                    { 185, null, 67, "DDR5-4000" },
                    { 186, null, 67, "DDR5-5400" },
                    { 187, null, 67, "DDR5-5800" },
                    { 188, null, 67, "DDR5-6800" },
                    { 189, null, 67, "DDR5-7000" },
                    { 190, null, 67, "DDR5-7200" },
                    { 191, null, 67, "DDR5-7400" },
                    { 192, null, 67, "DDR5-7600" },
                    { 193, null, 51, "2280/22110 M-key X4" },
                    { 194, null, 68, "DDR4-3200" },
                    { 195, null, 69, "288-pin DIMM (DDR4)" },
                    { 196, null, 70, "2 x 8GB" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 197, null, 71, "$2.499" },
                    { 198, null, 72, "Black / Yellow" },
                    { 199, null, 73, "10 ns" },
                    { 200, null, 74, "16" },
                    { 201, null, 75, "1.35 V" },
                    { 202, null, 76, "16-18-18-36" },
                    { 203, null, 77, "Non-ECC / Unbuffered" },
                    { 204, null, 78, "Yes" },
                    { 205, null, 68, "DDR5-5600" },
                    { 206, null, 69, "288-pin DIMM (DDR5)" },
                    { 207, null, 70, "2 x 16GB" },
                    { 208, null, 71, "$2.968" },
                    { 209, null, 72, "Black" },
                    { 210, null, 73, "12.857 ns" },
                    { 211, null, 74, "36" },
                    { 212, null, 75, "1.25 V" },
                    { 213, null, 76, "36-36-36-76" },
                    { 214, null, 68, "DDR4-3600" },
                    { 215, null, 74, "18" },
                    { 216, null, 76, "18-22-22-42" },
                    { 217, null, 68, "DDR5-6000" },
                    { 218, null, 71, "$3.125" },
                    { 219, null, 73, "12 ns" },
                    { 220, null, 76, "36-36-36-96" },
                    { 221, null, 79, "2 TB" },
                    { 222, null, 80, "$0.065" },
                    { 223, null, 81, "SSD" },
                    { 224, null, 82, "2048 MB" },
                    { 225, null, 83, "M.2-2280" },
                    { 226, null, 84, "M.2 PCIe 4.0 X4" },
                    { 227, null, 85, "Yes" },
                    { 228, null, 80, "$0.026" },
                    { 229, null, 81, "7200 RPM" },
                    { 230, null, 82, "256 MB" },
                    { 231, null, 83, "3.5\"" },
                    { 232, null, 84, "SATA 6.0 Gb/s" },
                    { 233, null, 85, "No" },
                    { 234, null, 79, "240 GB" },
                    { 235, null, 80, "$0.092" },
                    { 236, null, 83, "2.5\"" },
                    { 237, null, 79, "4 TB" },
                    { 238, null, 80, "$0.040" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 239, null, 84, "M.2 PCIe 3.0 X4" },
                    { 240, null, 86, "GeForce RTX 3060 Ventus 2X 12G" },
                    { 241, null, 87, "GeForce RTX 3060 12GB" },
                    { 242, null, 88, "12 GB" },
                    { 243, null, 89, "GDDR6" },
                    { 244, null, 90, "1320 MHz" },
                    { 245, null, 91, "1777 MHz" },
                    { 246, null, 92, "15000 MHz" },
                    { 247, null, 93, "PCIe x16" },
                    { 248, null, 94, "Black" },
                    { 249, null, 95, "G-Sync" },
                    { 250, null, 96, "235 mm" },
                    { 251, null, 97, "170 W" },
                    { 252, null, 98, "2" },
                    { 253, null, 99, "2" },
                    { 254, null, 100, "2 Fans" },
                    { 255, null, 101, "1 PCIe 8-pin" },
                    { 256, null, 102, "1" },
                    { 257, null, 103, "3" },
                    { 258, null, 87, "GeForce RTX 4070" },
                    { 259, null, 89, "GDDR6X" },
                    { 260, null, 90, "1920 MHz" },
                    { 261, null, 91, "2490 MHz" },
                    { 262, null, 96, "261 mm" },
                    { 263, null, 97, "200 W" },
                    { 264, null, 99, "3" },
                    { 265, null, 100, "3 Fans" },
                    { 266, null, 104, "1" },
                    { 267, null, 105, "3" },
                    { 268, null, 87, "GeForce RTX 4090" },
                    { 269, null, 88, "24 GB" },
                    { 270, null, 90, "2235 MHz" },
                    { 271, null, 91, "2640 MHz" },
                    { 272, null, 92, "21000 MHz" },
                    { 273, null, 96, "358 mm" },
                    { 274, null, 97, "450 W" },
                    { 275, null, 99, "4" },
                    { 276, null, 101, "1 PCIe 16-pin" },
                    { 277, null, 104, "2" },
                    { 278, null, 106, "3" },
                    { 279, null, 86, "RTX 3060 Ventus 3X 12G OC" },
                    { 280, null, 91, "1807 MHz" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 281, null, 96, "316 mm" },
                    { 282, null, 107, "RM750e (2023)" },
                    { 283, null, 108, "ATX" },
                    { 284, null, 109, "80+ Gold" },
                    { 285, null, 110, "750 W" },
                    { 286, null, 111, "140 mm" },
                    { 287, null, 112, "Full" },
                    { 288, null, 113, "Black" },
                    { 289, null, 114, "No" },
                    { 290, null, 115, "0" },
                    { 291, null, 116, "2" },
                    { 292, null, 117, "1" },
                    { 293, null, 118, "0" },
                    { 294, null, 119, "0" },
                    { 295, null, 120, "3" },
                    { 296, null, 121, "0" },
                    { 297, null, 122, "7" },
                    { 298, null, 123, "4" },
                    { 299, null, 107, "Toughpower GX2" },
                    { 300, null, 110, "600 W" },
                    { 301, null, 112, "No" },
                    { 302, null, 116, "1" },
                    { 303, null, 117, "0" },
                    { 304, null, 120, "2" },
                    { 305, null, 122, "6" },
                    { 306, null, 123, "3" },
                    { 307, null, 110, "650 W" },
                    { 308, null, 111, "160 mm" },
                    { 309, null, 120, "6" },
                    { 310, null, 122, "8" },
                    { 311, null, 123, "5" },
                    { 312, null, 109, "80+" },
                    { 313, null, 110, "500 W" },
                    { 314, null, 111, "139 mm" },
                    { 315, null, 124, "ATX Mid Tower" },
                    { 316, null, 125, "Black" },
                    { 317, null, 126, "None" },
                    { 318, null, 127, "Tempered Glass" },
                    { 319, null, 128, "Yes" },
                    { 320, null, 129, "USB 3.2 Gen 1 Type-A" },
                    { 321, null, 129, "USB 2.0 Type-A" },
                    { 322, null, 130, "ATX" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 323, null, 130, "Micro ATX" },
                    { 324, null, 130, "Mini ITX" },
                    { 325, null, 131, "370 mm / 14.567\"" },
                    { 326, null, 132, "2 x Internal 3.5\"" },
                    { 327, null, 132, "2 x Internal 2.5\"" },
                    { 328, null, 133, "7 x Full-Height" },
                    { 329, null, 134, "416 mm x 210 mm x 477 mm" },
                    { 330, null, 134, "16.378\" x 8.268\" x 18.78\"" },
                    { 331, null, 135, "41.671 L" },
                    { 332, null, 135, "1.472 ft³" },
                    { 333, null, 129, "USB 3.2 Gen 2 Type-C" },
                    { 334, null, 130, "EATX" },
                    { 335, null, 131, "365 mm / 14.37\"" },
                    { 336, null, 132, "1 x Internal 3.5\"" },
                    { 337, null, 132, "1 x Internal 2.5\"" },
                    { 338, null, 134, "446 mm x 227 mm x 464 mm" },
                    { 339, null, 134, "17.559\" x 8.937\" x 18.268\"" },
                    { 340, null, 135, "46.976 L" },
                    { 341, null, 135, "1.659 ft³" },
                    { 342, null, 125, "White / Gray" },
                    { 343, null, 131, "422 mm / 16.614\"" },
                    { 344, null, 132, "6 x Internal 3.5\"" },
                    { 345, null, 132, "3 x Internal 2.5\"" },
                    { 346, null, 133, "8 x Full-Height" },
                    { 347, null, 134, "465 mm x 285 mm x 459 mm" },
                    { 348, null, 134, "18.307\" x 11.22\" x 18.071\"" },
                    { 349, null, 135, "60.829 L" },
                    { 350, null, 135, "2.148 ft³" },
                    { 351, null, 131, "300 mm / 11.811\" With Drive Cages" },
                    { 352, null, 131, "355 mm / 13.976\" Without Drive Cages" },
                    { 353, null, 134, "447 mm x 215 mm x 469 mm" },
                    { 354, null, 134, "17.598\" x 8.465\" x 18.465\"" },
                    { 355, null, 135, "45.073 L" },
                    { 356, null, 135, "1.592 ft³" },
                    { 357, null, 136, "HyperX Cloud II" },
                    { 358, null, 137, "Circumaural" },
                    { 359, null, 138, "15 Hz - 25 kHz" },
                    { 360, null, 139, "Yes" },
                    { 361, null, 140, "No" },
                    { 362, null, 141, "Closed" },
                    { 363, null, 142, "Black / Red" },
                    { 364, null, 143, "No" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 365, null, 144, "Stereo 3.5mm Audio" },
                    { 366, null, 144, "USB Type-A" },
                    { 367, null, 145, "7.1" },
                    { 368, null, 146, "60 Ω" },
                    { 369, null, 147, "98 dB" },
                    { 370, null, 136, "BlackShark V2 X" },
                    { 371, null, 138, "12 Hz - 28 kHz" },
                    { 372, null, 142, "Black / Green" },
                    { 373, null, 146, "32 Ω" },
                    { 374, null, 147, "100 dB" },
                    { 375, null, 136, "Pro X" },
                    { 376, null, 138, "20 Hz - 20 kHz" },
                    { 377, null, 142, "Black" },
                    { 378, null, 146, "35 Ω" },
                    { 379, null, 147, "91.7 dB" },
                    { 380, null, 148, "78.74\"" },
                    { 381, null, 136, "Kraken Kitty" },
                    { 382, null, 142, "Pink" },
                    { 383, null, 145, "2.0" },
                    { 384, null, 147, "109 dB" },
                    { 385, null, 148, "51.181\"" },
                    { 386, null, 149, "K60 RGB Pro" },
                    { 387, null, 150, "Gaming" },
                    { 388, null, 151, "Yes" },
                    { 389, null, 152, "Cherry Viola" },
                    { 390, null, 153, "RGB" },
                    { 391, null, 154, "No" },
                    { 392, null, 155, "Wired" },
                    { 393, null, 156, "Black" },
                    { 394, null, 157, "No" },
                    { 395, null, 149, "K120" },
                    { 396, null, 150, "Standard" },
                    { 397, null, 151, "No" },
                    { 398, null, 153, "None" },
                    { 399, null, 149, "Huntsman Mini" },
                    { 400, null, 150, "Mini" },
                    { 401, null, 152, "Razer Purple Optical Clicky" },
                    { 402, null, 154, "Yes" },
                    { 403, null, 156, "White" },
                    { 404, null, 149, "BlackWidow V3" },
                    { 405, null, 152, "Razer Green" },
                    { 406, null, 158, "G502 HERO" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 407, null, 159, "Optical" },
                    { 408, null, 160, "Wired" },
                    { 409, null, 161, "25600" },
                    { 410, null, 162, "Right" },
                    { 411, null, 158, "Basilisk V3" },
                    { 412, null, 161, "26000" },
                    { 413, null, 161, "6400" },
                    { 414, null, 163, "White" },
                    { 415, null, 158, "Viper Mini" },
                    { 416, null, 161, "8500" },
                    { 417, null, 163, "Black" },
                    { 418, null, 164, "Z200" },
                    { 419, null, 165, "2.0" },
                    { 420, null, 166, "10 W" },
                    { 421, null, 167, "20 Hz - 20 kHz" },
                    { 422, null, 168, "5 W" },
                    { 423, null, 164, "Z906" },
                    { 424, null, 165, "5.1" },
                    { 425, null, 166, "500 W" },
                    { 426, null, 167, "35 Hz - 20 kHz" },
                    { 427, null, 168, "67 W" },
                    { 428, null, 169, "67 W" },
                    { 429, null, 170, "67 W" },
                    { 430, null, 171, "165 W" },
                    { 431, null, 165, "2.1" },
                    { 432, null, 166, "65 W" },
                    { 433, null, 167, "45 Hz - 20 kHz" },
                    { 434, null, 168, "32.5 W" },
                    { 435, null, 172, "Black" },
                    { 436, null, 164, "Creative Stage V2" },
                    { 437, null, 166, "80 W" },
                    { 438, null, 167, "55 Hz - 20 kHz" },
                    { 439, null, 168, "20 W" },
                    { 440, null, 171, "40 W" },
                    { 441, null, 173, "BRIO Ultra HD Pro" },
                    { 442, null, 174, "4k" },
                    { 443, null, 174, "1080p" },
                    { 444, null, 174, "720p" },
                    { 445, null, 175, "USB 3.2 Gen 1 Type-A" },
                    { 446, null, 176, "Auto" },
                    { 447, null, 177, "Windows" },
                    { 448, null, 177, "OS X" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 449, null, 177, "ChromeOS" },
                    { 450, null, 178, "82°" },
                    { 451, null, 179, "5X" },
                    { 452, null, 180, "Yes" },
                    { 453, null, 181, "No" },
                    { 454, null, 182, "Yes" },
                    { 455, null, 183, "Yes" },
                    { 456, null, 173, "Kiyo Pro Ultra" },
                    { 457, null, 174, "2k" },
                    { 458, null, 184, "8.3 MP" },
                    { 459, null, 185, "TUF Gaming VG27AQ" },
                    { 460, null, 186, "27\"" },
                    { 461, null, 187, "2560 x 1440" },
                    { 462, null, 188, "165 Hz" },
                    { 463, null, 189, "1 ms" },
                    { 464, null, 190, "IPS" },
                    { 465, null, 191, "16:9" },
                    { 466, null, 192, "Black" },
                    { 467, null, 193, "350 cd/m²" },
                    { 468, null, 194, "Yes" },
                    { 469, null, 195, "No" },
                    { 470, null, 196, "FreeSync" },
                    { 471, null, 196, "G-Sync Compatible" },
                    { 472, null, 197, "Yes" },
                    { 473, null, 198, "178° H x 178° V" },
                    { 474, null, 199, "2 x HDMI" },
                    { 475, null, 199, "1 x DisplayPort" },
                    { 476, null, 185, "Odyssey G7" },
                    { 477, null, 188, "240 Hz" },
                    { 478, null, 190, "VA" },
                    { 479, null, 196, "FreeSync Premium Pro" },
                    { 480, null, 197, "No" },
                    { 481, null, 199, "1 x HDMI" },
                    { 482, null, 199, "2 x DisplayPort" },
                    { 483, null, 200, "HDR 600" },
                    { 484, null, 201, "1000R" },
                    { 485, null, 187, "1920 x 1080" },
                    { 486, null, 192, "Silver / Black" },
                    { 487, null, 193, "250 cd/m²" },
                    { 488, null, 195, "Yes" },
                    { 489, null, 201, "1500R" },
                    { 490, null, 199, "2 x HDMI 2.0" }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "Metric", "SpecificationId", "Value" },
                values: new object[,]
                {
                    { 491, null, 199, "1 x DisplayPort 1.2" },
                    { 492, null, 202, "0.5 ms" },
                    { 493, null, 173, "C270" },
                    { 494, null, 175, "USB 2.0 Type-A" },
                    { 495, null, 176, "Fixed" },
                    { 496, null, 177, "Android" },
                    { 497, null, 178, "60°" },
                    { 498, null, 180, "No" },
                    { 499, null, 173, "Kiyo" },
                    { 500, null, 174, "480p" },
                    { 501, null, 178, "81.6°" },
                    { 502, null, 184, "4 MP" },
                    { 503, null, 181, "Yes" },
                    { 504, null, 193, "300 cd/m²" },
                    { 505, null, 200, "HDR10" },
                    { 506, null, 196, "FreeSync Premium" },
                    { 507, null, 199, "1 x DisplayPort 1.4" },
                    { 508, null, 203, "100 x 100" }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 3, 3, 9 },
                    { 4, 3, 10 },
                    { 5, 3, 11 },
                    { 6, 3, 12 },
                    { 7, 3, 13 },
                    { 8, 3, 14 },
                    { 9, 3, 15 },
                    { 10, 3, 16 },
                    { 11, 3, 17 },
                    { 12, 3, 18 },
                    { 13, 3, 19 },
                    { 14, 3, 20 },
                    { 15, 3, 21 },
                    { 16, 3, 22 },
                    { 17, 3, 23 },
                    { 18, 3, 24 },
                    { 19, 3, 25 },
                    { 20, 3, 26 },
                    { 21, 3, 27 },
                    { 22, 3, 28 },
                    { 23, 4, 29 },
                    { 24, 4, 30 },
                    { 25, 4, 31 },
                    { 26, 4, 32 },
                    { 27, 4, 33 },
                    { 28, 4, 34 },
                    { 29, 4, 35 },
                    { 30, 4, 36 },
                    { 31, 4, 37 },
                    { 32, 4, 18 },
                    { 33, 4, 38 },
                    { 34, 4, 39 },
                    { 35, 4, 21 },
                    { 36, 4, 40 },
                    { 37, 4, 41 },
                    { 38, 4, 42 },
                    { 39, 4, 43 },
                    { 40, 4, 44 },
                    { 41, 4, 45 },
                    { 42, 4, 28 },
                    { 43, 5, 46 },
                    { 44, 5, 47 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 45, 5, 48 },
                    { 46, 5, 49 },
                    { 47, 5, 50 },
                    { 48, 5, 51 },
                    { 49, 5, 52 },
                    { 50, 5, 53 },
                    { 51, 5, 54 },
                    { 52, 5, 55 },
                    { 53, 5, 38 },
                    { 54, 5, 39 },
                    { 55, 5, 21 },
                    { 56, 5, 40 },
                    { 57, 5, 56 },
                    { 58, 5, 61 },
                    { 59, 5, 62 },
                    { 60, 5, 57 },
                    { 61, 5, 63 },
                    { 62, 5, 58 },
                    { 63, 5, 59 },
                    { 64, 5, 45 },
                    { 65, 5, 60 },
                    { 66, 6, 29 },
                    { 67, 6, 64 },
                    { 68, 6, 65 },
                    { 69, 6, 66 },
                    { 70, 6, 33 },
                    { 71, 6, 14 },
                    { 72, 6, 15 },
                    { 73, 6, 16 },
                    { 74, 6, 17 },
                    { 75, 6, 18 },
                    { 76, 6, 19 },
                    { 77, 6, 39 },
                    { 78, 6, 21 },
                    { 79, 6, 40 },
                    { 80, 6, 41 },
                    { 81, 6, 67 },
                    { 82, 6, 25 },
                    { 83, 6, 26 },
                    { 84, 6, 45 },
                    { 85, 6, 28 },
                    { 86, 7, 68 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 87, 7, 69 },
                    { 88, 7, 70 },
                    { 89, 7, 71 },
                    { 90, 7, 72 },
                    { 91, 7, 73 },
                    { 92, 7, 74 },
                    { 93, 7, 75 },
                    { 94, 7, 76 },
                    { 95, 7, 77 },
                    { 96, 7, 78 },
                    { 97, 7, 79 },
                    { 98, 7, 80 },
                    { 99, 7, 81 },
                    { 100, 7, 82 },
                    { 101, 7, 83 },
                    { 102, 7, 84 },
                    { 103, 7, 85 },
                    { 104, 7, 86 },
                    { 105, 7, 87 },
                    { 106, 7, 88 },
                    { 107, 7, 89 },
                    { 108, 7, 90 },
                    { 109, 7, 91 },
                    { 110, 7, 92 },
                    { 111, 8, 93 },
                    { 112, 8, 94 },
                    { 113, 8, 95 },
                    { 114, 8, 96 },
                    { 115, 8, 73 },
                    { 116, 8, 74 },
                    { 117, 8, 75 },
                    { 118, 8, 76 },
                    { 119, 8, 77 },
                    { 120, 8, 78 },
                    { 121, 8, 79 },
                    { 122, 8, 80 },
                    { 123, 8, 81 },
                    { 124, 8, 82 },
                    { 125, 8, 83 },
                    { 126, 8, 84 },
                    { 127, 8, 85 },
                    { 128, 8, 86 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 129, 8, 87 },
                    { 130, 8, 88 },
                    { 131, 8, 89 },
                    { 132, 8, 90 },
                    { 133, 8, 91 },
                    { 134, 8, 92 },
                    { 135, 8, 97 },
                    { 136, 9, 98 },
                    { 137, 9, 99 },
                    { 138, 9, 100 },
                    { 139, 9, 97 },
                    { 140, 9, 101 },
                    { 141, 9, 72 },
                    { 142, 9, 73 },
                    { 143, 9, 74 },
                    { 144, 9, 75 },
                    { 145, 9, 76 },
                    { 146, 9, 77 },
                    { 147, 9, 78 },
                    { 148, 9, 79 },
                    { 149, 9, 80 },
                    { 150, 9, 81 },
                    { 151, 9, 82 },
                    { 152, 9, 83 },
                    { 153, 9, 84 },
                    { 154, 9, 85 },
                    { 155, 9, 86 },
                    { 156, 9, 87 },
                    { 157, 9, 88 },
                    { 158, 9, 89 },
                    { 159, 9, 90 },
                    { 160, 9, 91 },
                    { 161, 9, 92 },
                    { 162, 10, 102 },
                    { 163, 10, 103 },
                    { 164, 10, 104 },
                    { 165, 10, 97 },
                    { 166, 10, 105 },
                    { 167, 10, 73 },
                    { 168, 10, 78 },
                    { 169, 10, 79 },
                    { 170, 10, 106 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 171, 10, 107 },
                    { 172, 10, 83 },
                    { 173, 10, 83 },
                    { 174, 10, 84 },
                    { 175, 10, 85 },
                    { 176, 10, 86 },
                    { 177, 10, 87 },
                    { 178, 10, 89 },
                    { 179, 10, 90 },
                    { 180, 10, 91 },
                    { 181, 10, 92 },
                    { 182, 11, 108 },
                    { 183, 11, 109 },
                    { 184, 11, 110 },
                    { 185, 11, 111 },
                    { 186, 11, 112 },
                    { 187, 11, 113 },
                    { 188, 11, 114 },
                    { 189, 11, 115 },
                    { 190, 11, 116 },
                    { 191, 11, 117 },
                    { 192, 11, 118 },
                    { 193, 11, 119 },
                    { 194, 11, 120 },
                    { 195, 11, 121 },
                    { 196, 11, 122 },
                    { 197, 11, 123 },
                    { 198, 11, 124 },
                    { 199, 11, 125 },
                    { 200, 11, 126 },
                    { 201, 11, 127 },
                    { 202, 11, 128 },
                    { 203, 11, 129 },
                    { 204, 11, 130 },
                    { 205, 11, 131 },
                    { 206, 11, 132 },
                    { 207, 11, 133 },
                    { 208, 11, 134 },
                    { 209, 11, 135 },
                    { 210, 11, 136 },
                    { 211, 11, 137 },
                    { 212, 11, 138 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 213, 11, 139 },
                    { 214, 11, 140 },
                    { 215, 11, 141 },
                    { 216, 11, 142 },
                    { 217, 11, 143 },
                    { 218, 11, 144 },
                    { 219, 11, 145 },
                    { 220, 11, 146 },
                    { 221, 11, 147 },
                    { 222, 11, 148 },
                    { 223, 11, 149 },
                    { 224, 11, 150 },
                    { 225, 11, 151 },
                    { 226, 11, 152 },
                    { 227, 12, 153 },
                    { 228, 12, 109 },
                    { 229, 12, 154 },
                    { 230, 12, 155 },
                    { 231, 12, 156 },
                    { 232, 12, 113 },
                    { 233, 12, 157 },
                    { 234, 12, 158 },
                    { 235, 12, 159 },
                    { 236, 12, 160 },
                    { 237, 12, 161 },
                    { 238, 12, 162 },
                    { 239, 12, 163 },
                    { 240, 12, 164 },
                    { 241, 12, 165 },
                    { 242, 12, 166 },
                    { 243, 12, 117 },
                    { 244, 12, 118 },
                    { 245, 12, 167 },
                    { 246, 12, 120 },
                    { 247, 12, 168 },
                    { 248, 12, 122 },
                    { 249, 12, 123 },
                    { 250, 12, 124 },
                    { 251, 12, 125 },
                    { 252, 12, 169 },
                    { 253, 12, 170 },
                    { 254, 12, 128 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 255, 12, 129 },
                    { 256, 12, 130 },
                    { 257, 12, 131 },
                    { 258, 12, 132 },
                    { 259, 12, 171 },
                    { 260, 12, 134 },
                    { 261, 12, 172 },
                    { 262, 12, 136 },
                    { 263, 13, 108 },
                    { 264, 13, 109 },
                    { 265, 13, 110 },
                    { 266, 13, 111 },
                    { 267, 13, 112 },
                    { 268, 13, 113 },
                    { 269, 13, 165 },
                    { 270, 13, 115 },
                    { 271, 13, 116 },
                    { 272, 13, 117 },
                    { 273, 13, 118 },
                    { 274, 13, 173 },
                    { 275, 13, 120 },
                    { 276, 13, 174 },
                    { 277, 13, 175 },
                    { 278, 13, 122 },
                    { 279, 13, 123 },
                    { 280, 13, 124 },
                    { 281, 13, 125 },
                    { 282, 13, 126 },
                    { 283, 13, 176 },
                    { 284, 13, 177 },
                    { 285, 13, 128 },
                    { 286, 13, 129 },
                    { 287, 13, 130 },
                    { 288, 13, 131 },
                    { 289, 13, 178 },
                    { 290, 13, 133 },
                    { 291, 13, 134 },
                    { 292, 13, 135 },
                    { 293, 13, 136 },
                    { 294, 13, 137 },
                    { 295, 13, 138 },
                    { 296, 13, 139 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 297, 13, 140 },
                    { 298, 13, 141 },
                    { 299, 13, 142 },
                    { 300, 13, 143 },
                    { 301, 13, 144 },
                    { 302, 13, 145 },
                    { 303, 13, 146 },
                    { 304, 13, 147 },
                    { 305, 13, 148 },
                    { 306, 13, 149 },
                    { 307, 13, 150 },
                    { 308, 13, 151 },
                    { 309, 13, 152 },
                    { 310, 13, 179 },
                    { 311, 13, 180 },
                    { 312, 13, 181 },
                    { 313, 13, 182 },
                    { 314, 14, 183 },
                    { 315, 14, 109 },
                    { 316, 14, 184 },
                    { 317, 14, 155 },
                    { 318, 14, 156 },
                    { 319, 14, 113 },
                    { 320, 14, 185 },
                    { 321, 14, 158 },
                    { 322, 14, 159 },
                    { 323, 14, 186 },
                    { 324, 14, 160 },
                    { 325, 14, 187 },
                    { 326, 14, 161 },
                    { 327, 14, 162 },
                    { 328, 14, 163 },
                    { 329, 14, 164 },
                    { 330, 14, 188 },
                    { 331, 14, 189 },
                    { 332, 14, 190 },
                    { 333, 14, 191 },
                    { 334, 14, 192 },
                    { 335, 14, 114 },
                    { 336, 14, 115 },
                    { 337, 14, 166 },
                    { 338, 14, 117 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 339, 14, 118 },
                    { 340, 14, 167 },
                    { 341, 14, 120 },
                    { 342, 14, 193 },
                    { 343, 14, 122 },
                    { 344, 14, 123 },
                    { 345, 14, 124 },
                    { 346, 14, 125 },
                    { 347, 14, 126 },
                    { 348, 14, 170 },
                    { 349, 14, 128 },
                    { 350, 14, 129 },
                    { 351, 14, 130 },
                    { 352, 14, 131 },
                    { 353, 14, 178 },
                    { 354, 14, 133 },
                    { 355, 14, 134 },
                    { 356, 14, 172 },
                    { 357, 14, 136 },
                    { 358, 15, 194 },
                    { 359, 15, 195 },
                    { 360, 15, 196 },
                    { 361, 15, 197 },
                    { 362, 15, 198 },
                    { 363, 15, 199 },
                    { 364, 15, 200 },
                    { 365, 15, 201 },
                    { 366, 15, 202 },
                    { 367, 15, 203 },
                    { 368, 15, 204 },
                    { 369, 16, 205 },
                    { 370, 16, 206 },
                    { 371, 16, 207 },
                    { 372, 16, 208 },
                    { 373, 16, 209 },
                    { 374, 16, 210 },
                    { 375, 16, 211 },
                    { 376, 16, 212 },
                    { 377, 16, 213 },
                    { 378, 16, 203 },
                    { 379, 16, 204 },
                    { 380, 17, 214 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 381, 17, 195 },
                    { 382, 17, 207 },
                    { 383, 17, 208 },
                    { 384, 17, 209 },
                    { 385, 17, 199 },
                    { 386, 17, 215 },
                    { 387, 17, 201 },
                    { 388, 17, 216 },
                    { 389, 17, 203 },
                    { 390, 17, 204 },
                    { 391, 18, 217 },
                    { 392, 18, 206 },
                    { 393, 18, 207 },
                    { 394, 18, 218 },
                    { 395, 18, 209 },
                    { 396, 18, 219 },
                    { 397, 18, 211 },
                    { 398, 18, 201 },
                    { 399, 18, 220 },
                    { 400, 18, 203 },
                    { 401, 18, 204 },
                    { 402, 19, 221 },
                    { 403, 19, 222 },
                    { 404, 19, 223 },
                    { 405, 19, 224 },
                    { 406, 19, 225 },
                    { 407, 19, 226 },
                    { 408, 19, 227 },
                    { 409, 20, 221 },
                    { 410, 20, 228 },
                    { 411, 20, 229 },
                    { 412, 20, 230 },
                    { 413, 20, 231 },
                    { 414, 20, 232 },
                    { 415, 20, 233 },
                    { 416, 21, 234 },
                    { 417, 21, 235 },
                    { 418, 21, 223 },
                    { 419, 21, 236 },
                    { 420, 21, 232 },
                    { 421, 21, 233 },
                    { 422, 22, 237 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 423, 22, 238 },
                    { 424, 22, 223 },
                    { 425, 22, 225 },
                    { 426, 22, 239 },
                    { 427, 22, 227 },
                    { 428, 23, 240 },
                    { 429, 23, 241 },
                    { 430, 23, 242 },
                    { 431, 23, 243 },
                    { 432, 23, 244 },
                    { 433, 23, 245 },
                    { 434, 23, 246 },
                    { 435, 23, 247 },
                    { 436, 23, 248 },
                    { 437, 23, 249 },
                    { 438, 23, 250 },
                    { 439, 23, 251 },
                    { 440, 23, 252 },
                    { 441, 23, 253 },
                    { 442, 23, 254 },
                    { 443, 23, 255 },
                    { 444, 23, 256 },
                    { 445, 23, 257 },
                    { 446, 24, 258 },
                    { 447, 24, 242 },
                    { 448, 24, 259 },
                    { 449, 24, 260 },
                    { 450, 24, 261 },
                    { 451, 24, 247 },
                    { 452, 24, 248 },
                    { 453, 24, 249 },
                    { 454, 24, 262 },
                    { 455, 24, 263 },
                    { 456, 24, 252 },
                    { 457, 24, 264 },
                    { 458, 24, 265 },
                    { 459, 24, 255 },
                    { 460, 24, 266 },
                    { 461, 24, 267 },
                    { 462, 25, 268 },
                    { 463, 25, 269 },
                    { 464, 25, 259 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 465, 25, 270 },
                    { 466, 25, 271 },
                    { 467, 25, 272 },
                    { 468, 25, 247 },
                    { 469, 25, 248 },
                    { 470, 25, 249 },
                    { 471, 25, 273 },
                    { 472, 25, 274 },
                    { 473, 25, 252 },
                    { 474, 25, 275 },
                    { 475, 25, 265 },
                    { 476, 25, 276 },
                    { 477, 25, 277 },
                    { 478, 25, 278 },
                    { 479, 26, 279 },
                    { 480, 26, 241 },
                    { 481, 26, 242 },
                    { 482, 26, 243 },
                    { 483, 26, 244 },
                    { 484, 26, 280 },
                    { 485, 26, 246 },
                    { 486, 26, 247 },
                    { 487, 26, 248 },
                    { 488, 26, 249 },
                    { 489, 26, 281 },
                    { 490, 26, 251 },
                    { 491, 26, 252 },
                    { 492, 26, 253 },
                    { 493, 26, 265 },
                    { 494, 26, 255 },
                    { 495, 26, 256 },
                    { 496, 26, 257 },
                    { 497, 27, 282 },
                    { 498, 27, 283 },
                    { 499, 27, 284 },
                    { 500, 27, 285 },
                    { 501, 27, 286 },
                    { 502, 27, 287 },
                    { 503, 27, 288 },
                    { 504, 27, 289 },
                    { 505, 27, 290 },
                    { 506, 27, 291 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 507, 27, 292 },
                    { 508, 27, 293 },
                    { 509, 27, 294 },
                    { 510, 27, 295 },
                    { 511, 27, 296 },
                    { 512, 27, 297 },
                    { 513, 27, 298 },
                    { 514, 28, 299 },
                    { 515, 28, 283 },
                    { 516, 28, 284 },
                    { 517, 28, 300 },
                    { 518, 28, 286 },
                    { 519, 28, 301 },
                    { 520, 28, 288 },
                    { 521, 28, 289 },
                    { 522, 28, 290 },
                    { 523, 28, 302 },
                    { 524, 28, 303 },
                    { 525, 28, 293 },
                    { 526, 28, 294 },
                    { 527, 28, 304 },
                    { 528, 28, 296 },
                    { 529, 28, 305 },
                    { 530, 28, 306 },
                    { 531, 29, 283 },
                    { 532, 29, 284 },
                    { 533, 29, 307 },
                    { 534, 29, 308 },
                    { 535, 29, 287 },
                    { 536, 29, 288 },
                    { 537, 29, 289 },
                    { 538, 29, 290 },
                    { 539, 29, 291 },
                    { 540, 29, 303 },
                    { 541, 29, 293 },
                    { 542, 29, 294 },
                    { 543, 29, 309 },
                    { 544, 29, 296 },
                    { 545, 29, 310 },
                    { 546, 29, 311 },
                    { 547, 30, 283 },
                    { 548, 30, 312 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 549, 30, 313 },
                    { 550, 30, 314 },
                    { 551, 30, 301 },
                    { 552, 30, 289 },
                    { 553, 30, 290 },
                    { 554, 30, 302 },
                    { 555, 30, 303 },
                    { 556, 30, 293 },
                    { 557, 30, 294 },
                    { 558, 30, 304 },
                    { 559, 30, 296 },
                    { 560, 30, 305 },
                    { 561, 30, 306 },
                    { 562, 31, 315 },
                    { 563, 31, 316 },
                    { 564, 31, 317 },
                    { 565, 31, 318 },
                    { 566, 31, 319 },
                    { 567, 31, 320 },
                    { 568, 31, 321 },
                    { 569, 31, 322 },
                    { 570, 31, 323 },
                    { 571, 31, 324 },
                    { 572, 31, 325 },
                    { 573, 31, 326 },
                    { 574, 31, 327 },
                    { 575, 31, 328 },
                    { 576, 31, 329 },
                    { 577, 31, 330 },
                    { 578, 31, 331 },
                    { 579, 31, 332 },
                    { 580, 32, 315 },
                    { 581, 32, 316 },
                    { 582, 32, 317 },
                    { 583, 32, 318 },
                    { 584, 32, 319 },
                    { 585, 32, 333 },
                    { 586, 32, 320 },
                    { 587, 32, 322 },
                    { 588, 32, 334 },
                    { 589, 32, 323 },
                    { 590, 32, 324 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 591, 32, 335 },
                    { 592, 32, 336 },
                    { 593, 32, 337 },
                    { 594, 32, 328 },
                    { 595, 32, 338 },
                    { 596, 32, 339 },
                    { 597, 32, 340 },
                    { 598, 32, 341 },
                    { 599, 33, 315 },
                    { 600, 33, 342 },
                    { 601, 33, 317 },
                    { 602, 33, 318 },
                    { 603, 33, 319 },
                    { 604, 33, 333 },
                    { 605, 33, 320 },
                    { 606, 33, 322 },
                    { 607, 33, 334 },
                    { 608, 33, 323 },
                    { 609, 33, 324 },
                    { 610, 33, 343 },
                    { 611, 33, 344 },
                    { 612, 33, 345 },
                    { 613, 33, 346 },
                    { 614, 33, 347 },
                    { 615, 33, 348 },
                    { 616, 33, 349 },
                    { 617, 33, 350 },
                    { 618, 34, 315 },
                    { 619, 34, 316 },
                    { 620, 34, 317 },
                    { 621, 34, 318 },
                    { 622, 34, 319 },
                    { 623, 34, 333 },
                    { 624, 34, 320 },
                    { 625, 34, 322 },
                    { 626, 34, 323 },
                    { 627, 34, 324 },
                    { 628, 34, 351 },
                    { 629, 34, 352 },
                    { 630, 34, 326 },
                    { 631, 34, 327 },
                    { 632, 34, 328 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 633, 34, 353 },
                    { 634, 34, 354 },
                    { 635, 34, 355 },
                    { 636, 34, 356 },
                    { 637, 35, 357 },
                    { 638, 35, 358 },
                    { 639, 35, 359 },
                    { 640, 35, 360 },
                    { 641, 35, 361 },
                    { 642, 35, 362 },
                    { 643, 35, 363 },
                    { 644, 35, 364 },
                    { 645, 35, 365 },
                    { 646, 35, 366 },
                    { 647, 35, 367 },
                    { 648, 35, 368 },
                    { 649, 35, 369 },
                    { 650, 36, 370 },
                    { 651, 36, 358 },
                    { 652, 36, 371 },
                    { 653, 36, 360 },
                    { 654, 36, 361 },
                    { 655, 36, 362 },
                    { 656, 36, 372 },
                    { 657, 36, 364 },
                    { 658, 36, 365 },
                    { 659, 36, 367 },
                    { 660, 36, 373 },
                    { 661, 36, 374 },
                    { 662, 37, 375 },
                    { 663, 37, 358 },
                    { 664, 37, 376 },
                    { 665, 37, 360 },
                    { 666, 37, 361 },
                    { 667, 37, 362 },
                    { 668, 37, 377 },
                    { 669, 37, 364 },
                    { 670, 37, 366 },
                    { 671, 37, 367 },
                    { 672, 37, 378 },
                    { 673, 37, 379 },
                    { 674, 37, 380 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 675, 38, 381 },
                    { 676, 38, 358 },
                    { 677, 38, 376 },
                    { 678, 38, 360 },
                    { 679, 38, 361 },
                    { 680, 38, 362 },
                    { 681, 38, 382 },
                    { 682, 38, 364 },
                    { 683, 38, 366 },
                    { 684, 38, 383 },
                    { 685, 38, 373 },
                    { 686, 38, 384 },
                    { 687, 38, 385 },
                    { 688, 39, 386 },
                    { 689, 39, 387 },
                    { 690, 39, 388 },
                    { 691, 39, 389 },
                    { 692, 39, 390 },
                    { 693, 39, 391 },
                    { 694, 39, 392 },
                    { 695, 39, 393 },
                    { 696, 39, 394 },
                    { 697, 40, 395 },
                    { 698, 40, 396 },
                    { 699, 40, 397 },
                    { 700, 40, 398 },
                    { 701, 40, 391 },
                    { 702, 40, 392 },
                    { 703, 40, 393 },
                    { 704, 40, 394 },
                    { 705, 41, 399 },
                    { 706, 41, 400 },
                    { 707, 41, 388 },
                    { 708, 41, 401 },
                    { 709, 41, 390 },
                    { 710, 41, 402 },
                    { 711, 41, 392 },
                    { 712, 41, 403 },
                    { 713, 41, 394 },
                    { 714, 42, 404 },
                    { 715, 42, 387 },
                    { 716, 42, 388 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 717, 42, 405 },
                    { 718, 42, 390 },
                    { 719, 42, 402 },
                    { 720, 42, 392 },
                    { 721, 42, 393 },
                    { 722, 42, 394 },
                    { 723, 43, 406 },
                    { 724, 43, 407 },
                    { 725, 43, 408 },
                    { 726, 43, 409 },
                    { 727, 43, 410 },
                    { 728, 44, 411 },
                    { 729, 44, 407 },
                    { 730, 44, 408 },
                    { 731, 44, 412 },
                    { 732, 44, 410 },
                    { 733, 45, 407 },
                    { 734, 45, 408 },
                    { 735, 45, 413 },
                    { 736, 45, 410 },
                    { 737, 45, 414 },
                    { 738, 46, 415 },
                    { 739, 46, 407 },
                    { 740, 46, 408 },
                    { 741, 46, 416 },
                    { 742, 46, 410 },
                    { 743, 46, 417 },
                    { 744, 47, 418 },
                    { 745, 47, 419 },
                    { 746, 47, 420 },
                    { 747, 47, 421 },
                    { 748, 47, 422 },
                    { 749, 48, 423 },
                    { 750, 48, 424 },
                    { 751, 48, 425 },
                    { 752, 48, 426 },
                    { 753, 48, 427 },
                    { 754, 48, 428 },
                    { 755, 48, 429 },
                    { 756, 48, 430 },
                    { 757, 49, 431 },
                    { 758, 49, 432 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 759, 49, 433 },
                    { 760, 49, 434 },
                    { 761, 49, 435 },
                    { 762, 50, 436 },
                    { 763, 50, 431 },
                    { 764, 50, 437 },
                    { 765, 50, 438 },
                    { 766, 50, 435 },
                    { 767, 50, 439 },
                    { 768, 50, 440 },
                    { 769, 51, 441 },
                    { 770, 51, 442 },
                    { 771, 51, 443 },
                    { 772, 51, 444 },
                    { 773, 51, 445 },
                    { 774, 51, 446 },
                    { 775, 51, 447 },
                    { 776, 51, 448 },
                    { 777, 51, 449 },
                    { 778, 51, 450 },
                    { 779, 51, 451 },
                    { 780, 51, 452 },
                    { 781, 51, 453 },
                    { 782, 51, 454 },
                    { 783, 51, 455 },
                    { 784, 52, 456 },
                    { 785, 52, 442 },
                    { 786, 52, 457 },
                    { 787, 52, 443 },
                    { 788, 52, 444 },
                    { 789, 52, 445 },
                    { 790, 52, 446 },
                    { 791, 52, 447 },
                    { 792, 52, 450 },
                    { 793, 52, 452 },
                    { 794, 52, 453 },
                    { 795, 52, 454 },
                    { 796, 52, 458 },
                    { 797, 53, 459 },
                    { 798, 53, 460 },
                    { 799, 53, 461 },
                    { 800, 53, 462 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 801, 53, 463 },
                    { 802, 53, 464 },
                    { 803, 53, 465 },
                    { 804, 53, 466 },
                    { 805, 53, 467 },
                    { 806, 53, 468 },
                    { 807, 53, 469 },
                    { 808, 53, 470 },
                    { 809, 53, 471 },
                    { 810, 53, 472 },
                    { 811, 53, 473 },
                    { 812, 53, 474 },
                    { 813, 53, 475 },
                    { 814, 54, 476 },
                    { 815, 54, 460 },
                    { 816, 54, 461 },
                    { 817, 54, 477 },
                    { 818, 54, 463 },
                    { 819, 54, 478 },
                    { 820, 54, 465 },
                    { 821, 54, 466 },
                    { 822, 54, 467 },
                    { 823, 54, 468 },
                    { 824, 54, 479 },
                    { 825, 54, 471 },
                    { 826, 54, 480 },
                    { 827, 54, 473 },
                    { 828, 54, 481 },
                    { 829, 54, 482 },
                    { 830, 54, 483 },
                    { 831, 54, 484 },
                    { 832, 55, 460 },
                    { 833, 55, 485 },
                    { 834, 55, 477 },
                    { 835, 55, 492 },
                    { 836, 55, 478 },
                    { 837, 55, 465 },
                    { 838, 55, 486 },
                    { 839, 55, 487 },
                    { 840, 55, 468 },
                    { 841, 55, 488 },
                    { 842, 55, 489 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 843, 55, 470 },
                    { 844, 55, 480 },
                    { 845, 55, 473 },
                    { 846, 55, 490 },
                    { 847, 55, 491 },
                    { 848, 56, 493 },
                    { 849, 56, 444 },
                    { 850, 56, 494 },
                    { 851, 56, 495 },
                    { 852, 56, 447 },
                    { 853, 56, 448 },
                    { 854, 56, 449 },
                    { 855, 56, 496 },
                    { 856, 56, 497 },
                    { 857, 56, 498 },
                    { 858, 56, 453 },
                    { 859, 56, 454 },
                    { 860, 57, 499 },
                    { 861, 57, 443 },
                    { 862, 57, 444 },
                    { 863, 57, 500 },
                    { 864, 57, 494 },
                    { 865, 57, 446 },
                    { 866, 57, 447 },
                    { 867, 57, 501 },
                    { 868, 57, 502 },
                    { 869, 57, 498 },
                    { 870, 57, 503 },
                    { 871, 57, 454 },
                    { 872, 58, 460 },
                    { 873, 58, 461 },
                    { 874, 58, 462 },
                    { 875, 58, 463 },
                    { 876, 58, 464 },
                    { 877, 58, 465 },
                    { 878, 58, 466 },
                    { 879, 58, 504 },
                    { 880, 58, 505 },
                    { 881, 58, 468 },
                    { 882, 58, 469 },
                    { 883, 58, 506 },
                    { 884, 58, 471 }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecificationValues",
                columns: new[] { "Id", "ProductId", "SpecificationValueId" },
                values: new object[,]
                {
                    { 885, 58, 480 },
                    { 886, 58, 508 },
                    { 887, 58, 473 },
                    { 888, 58, 474 },
                    { 889, 58, 507 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ApplicationUserId",
                table: "Address",
                column: "ApplicationUserId");

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
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_OrderId",
                table: "OrdersProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PartNumbers_ProductId",
                table: "PartNumbers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ApplicationUserId",
                table: "ProductReviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationValues_ProductId",
                table: "ProductSpecificationValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationValues_SpecificationValueId",
                table: "ProductSpecificationValues",
                column: "SpecificationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CategoryId",
                table: "Specifications",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValues_SpecificationId",
                table: "SpecificationValues",
                column: "SpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

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
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "PartNumbers");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "ProductSpecificationValues");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SpecificationValues");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
