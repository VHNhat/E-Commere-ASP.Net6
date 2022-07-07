using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class DataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountValue",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionRole",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Map = table.Column<string>(type: "text", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValueId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_DiscountValue_ValueId",
                        column: x => x.ValueId,
                        principalTable: "DiscountValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option_Role",
                columns: table => new
                {
                    OptionId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    RoleId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option_Role", x => new { x.RoleId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_Option_Role_OptionRole_OptionId",
                        column: x => x.OptionId,
                        principalTable: "OptionRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Option_Role_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    StoreId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Decription = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    TypeId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    DiscountId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
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
                        name: "FK_Product_ProductBrand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(767)", unicode: false, nullable: false),
                    RoleId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    UserId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    DiscountId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    ProductBrandId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    ProductId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    ProductTypeId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    StoreId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    UserId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_ProductBrand_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Size",
                columns: table => new
                {
                    ProductId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    SizeId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Size", x => new { x.SizeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Product_Size_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Size_ProductSize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "ProductSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Store",
                columns: table => new
                {
                    StoreId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ProductId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Store", x => new { x.StoreId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Product_Store_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Store_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Discount_ValueId",
                table: "Discount",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_Role_OptionId",
                table: "Option_Role",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_DiscountId",
                table: "Photo",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductBrandId",
                table: "Photo",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductId",
                table: "Photo",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductTypeId",
                table: "Photo",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_StoreId",
                table: "Photo",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DiscountId",
                table: "Product",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeId",
                table: "Product",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Size_ProductId",
                table: "Product_Size",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Store_ProductId",
                table: "Product_Store",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StoreId",
                table: "User",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Option_Role");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Product_Size");

            migrationBuilder.DropTable(
                name: "Product_Store");

            migrationBuilder.DropTable(
                name: "OptionRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "DiscountValue");
        }
    }
}
