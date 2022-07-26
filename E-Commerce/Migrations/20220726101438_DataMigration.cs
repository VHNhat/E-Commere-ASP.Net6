using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace E_Commerce.Migrations
{
    public partial class DataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoucherType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receiver",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Ward = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receiver_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    OptionId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => new { x.RoleId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_Permission_OptionRole_OptionId",
                        column: x => x.OptionId,
                        principalTable: "OptionRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Account_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: true),
                    IsCompany = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(type: "double", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "double", nullable: false, defaultValue: 0.0),
                    ExpiredAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_DiscountType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DiscountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discount_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBrand_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    AddBy = table.Column<int>(type: "int", nullable: false),
                    IsParent = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeCategories_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "double", nullable: false, defaultValue: 0.0),
                    ExpiredAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voucher_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Voucher_VoucherType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VoucherType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Decription = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false, defaultValue: -1),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    DiscountId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductBrand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    SizeCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_SizeCategories_SizeCategoryId",
                        column: x => x.SizeCategoryId,
                        principalTable: "SizeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SubTotal = table.Column<double>(type: "double", nullable: false),
                    ShippingCost = table.Column<double>(type: "double", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    VoucherId = table.Column<long>(type: "bigint", nullable: true),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Order_Receiver_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receiver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Order_Voucher_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Voucher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariance_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariance_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist_Product",
                columns: table => new
                {
                    WishlistId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist_Product", x => new { x.WishlistId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Wishlist_Product_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlist_Product_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductVarianceId = table.Column<long>(type: "bigint", nullable: false),
                    SizeId = table.Column<long>(type: "bigint", nullable: false),
                    DiscountId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => new { x.ProductId, x.ProductVarianceId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductDetail_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_ProductVariance_ProductVarianceId",
                        column: x => x.ProductVarianceId,
                        principalTable: "ProductVariance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductVarianceId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: true),
                    Rating = table.Column<double>(type: "double", nullable: false, defaultValue: 0.0),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewProduct_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ReviewProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewProduct_ProductVariance_ProductVarianceId",
                        column: x => x.ProductVarianceId,
                        principalTable: "ProductVariance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewProduct_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductDetailProductId = table.Column<long>(type: "bigint", nullable: true),
                    ProductDetailProductVarianceId = table.Column<long>(type: "bigint", nullable: true),
                    ProductDetailSizeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_ProductDetail_ProductDetailProductId_ProductDeta~",
                        columns: x => new { x.ProductDetailProductId, x.ProductDetailProductVarianceId, x.ProductDetailSizeId },
                        principalTable: "ProductDetail",
                        principalColumns: new[] { "ProductId", "ProductVarianceId", "SizeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OptionRole",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8021), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8024), "Get" },
                    { 2L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8028), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8028), "Post" },
                    { 3L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8030), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8031), "Put" },
                    { 4L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8033), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8034), "Delete" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(287), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(288), "admin" },
                    { 2L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(740), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(741), "shop-owner" },
                    { 3L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(743), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(744), "manager" },
                    { 4L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(746), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(747), "staff" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccountId", "Avatar", "CreatedAt", "FullName", "Gender", "LastModifiedAt", "OrganizerId", "Phone" },
                values: new object[,]
                {
                    { 1L, 1L, "photo.png", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(1483), "User 1", 1, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(1484), 1L, "0000000001" },
                    { 2L, 2L, "photo.png", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4089), "User 2", 0, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4090), 2L, "0000000002" },
                    { 3L, 3L, "photo.png", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4094), "User 3", 0, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4094), 3L, "0000000003" },
                    { 4L, 4L, "photo.png", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4097), "User 4", 1, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4098), 4L, "0000000004" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreatedAt", "Email", "LastModifiedAt", "Password", "RoleId", "UserId", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 7, 26, 17, 14, 36, 850, DateTimeKind.Local).AddTicks(3742), "email1@gmail.com", new DateTime(2022, 7, 26, 17, 14, 36, 850, DateTimeKind.Local).AddTicks(4238), "$2a$11$DAcPcRn4NSQz2CjtDpmfFuPeeLKVJnAxnhYxj7kfZ922eyR4UDRj2", 1L, 1L, "account1" },
                    { 2L, new DateTime(2022, 7, 26, 17, 14, 37, 71, DateTimeKind.Local).AddTicks(8430), "email2@gmail.com", new DateTime(2022, 7, 26, 17, 14, 37, 71, DateTimeKind.Local).AddTicks(8431), "$2a$11$93Vo78iq53DbSZ2PqxMNb.vLEseScXrJhxC727wNco0aPTwEqZyMa", 2L, 2L, "account2" },
                    { 3L, new DateTime(2022, 7, 26, 17, 14, 37, 290, DateTimeKind.Local).AddTicks(3953), "email3@gmail.com", new DateTime(2022, 7, 26, 17, 14, 37, 290, DateTimeKind.Local).AddTicks(3955), "$2a$11$HXPFJVtmEbgIlwcQDEAuguouqLC8lsz6BeSolfWBqrDUBDtFsCjdi", 3L, 3L, "account3" },
                    { 4L, new DateTime(2022, 7, 26, 17, 14, 37, 535, DateTimeKind.Local).AddTicks(513), "email4@gmail.com", new DateTime(2022, 7, 26, 17, 14, 37, 535, DateTimeKind.Local).AddTicks(514), "$2a$11$wMk1UqgqEwT0PyqCuQQ05uu93Te.LmHhWrO1q29hCzUX4LcBQk6L6", 4L, 4L, "account4" }
                });

            migrationBuilder.InsertData(
                table: "Organizer",
                columns: new[] { "Id", "Address", "CreatedAt", "Detail", "Email", "IsCompany", "LastModifiedAt", "Name", "Phone", "Photo", "UserId" },
                values: new object[,]
                {
                    { 1L, "address", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4850), "detail", "email@gmail.com", true, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(4851), "name", "0000000001", "photo", 1L },
                    { 2L, "address", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(7150), "detail", "email2@gmail.com", false, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(7151), "name", "0000000002", "photo", 2L },
                    { 3L, "address", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(7155), "detail", "email3@gmail.com", false, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(7156), "name", "0000000003", "photo", 3L },
                    { 4L, "address", new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(7159), "detail", "email4@gmail.com", true, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(7159), "name", "0000000004", "photo", 4L }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "OptionId", "RoleId", "CreatedAt", "LastModifiedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8595), new DateTime(2022, 7, 26, 17, 14, 37, 750, DateTimeKind.Local).AddTicks(8950) },
                    { 2L, 1L, new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(116), new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(119) },
                    { 3L, 1L, new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(120), new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(121) },
                    { 4L, 1L, new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(122), new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(123) },
                    { 1L, 2L, new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(124), new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(125) },
                    { 2L, 2L, new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(126), new DateTime(2022, 7, 26, 17, 14, 37, 751, DateTimeKind.Local).AddTicks(126) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username",
                table: "Account",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductDetailProductId_ProductDetailProductVaria~",
                table: "CartProduct",
                columns: new[] { "ProductDetailProductId", "ProductDetailProductVarianceId", "ProductDetailSizeId" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Phone",
                table: "Customer",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Username",
                table: "Customer",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discount_OrganizerId",
                table: "Discount",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_TypeId",
                table: "Discount",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ReceiverId",
                table: "Order",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VoucherId",
                table: "Order",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_Email",
                table: "Organizer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_Phone",
                table: "Organizer",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_UserId",
                table: "Organizer",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_OptionId",
                table: "Permission",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductId",
                table: "Photo",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DiscountId",
                table: "Product",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrganizerId",
                table: "Product",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrand_OrganizerId",
                table: "ProductBrand",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_OrganizerId",
                table: "ProductCategory",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_DiscountId",
                table: "ProductDetail",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductVarianceId",
                table: "ProductDetail",
                column: "ProductVarianceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_SizeId",
                table: "ProductDetail",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariance_OrganizerId",
                table: "ProductVariance",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariance_ProductId",
                table: "ProductVariance",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_CustomerId",
                table: "Receiver",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProduct_OrganizerId",
                table: "ReviewProduct",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProduct_ProductId",
                table: "ReviewProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProduct_ProductVarianceId",
                table: "ReviewProduct",
                column: "ProductVarianceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProduct_UserId",
                table: "ReviewProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_SizeCategoryId",
                table: "Size",
                column: "SizeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeCategories_OrganizerId",
                table: "SizeCategories",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Phone",
                table: "User",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_OrganizerId",
                table: "Voucher",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_TypeId",
                table: "Voucher",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Product_ProductId",
                table: "Wishlist_Product",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "ReviewProduct");

            migrationBuilder.DropTable(
                name: "Wishlist_Product");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "Receiver");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "OptionRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "ProductVariance");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "VoucherType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SizeCategories");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "DiscountType");

            migrationBuilder.DropTable(
                name: "Organizer");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
