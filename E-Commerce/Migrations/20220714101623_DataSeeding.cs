using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShoppingCart_Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 14, 17, 16, 23, 298, DateTimeKind.Local).AddTicks(6025),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 14, 17, 11, 22, 980, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[] { 1L, new DateTime(2022, 7, 14, 17, 16, 23, 302, DateTimeKind.Local).AddTicks(3686), new DateTime(2022, 7, 14, 17, 16, 23, 302, DateTimeKind.Local).AddTicks(3687), "admin" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "Address", "CreatedAt", "Detail", "LastModifiedAt", "Map", "Name", "Photo" },
                values: new object[] { 1L, "Đặng Thùy Trâm", new DateTime(2022, 7, 14, 17, 16, 23, 302, DateTimeKind.Local).AddTicks(6778), "cc", new DateTime(2022, 7, 14, 17, 16, 23, 302, DateTimeKind.Local).AddTicks(6778), "cc", "Unny mini house", "photo.png" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccountId", "CreatedAt", "Gender", "LastModifiedAt", "Name", "Phone", "Photo", "StoreId" },
                values: new object[] { 1L, 1L, new DateTime(2022, 7, 14, 17, 16, 23, 302, DateTimeKind.Local).AddTicks(4532), 1, new DateTime(2022, 7, 14, 17, 16, 23, 302, DateTimeKind.Local).AddTicks(4533), "Võ Hoàng Nhật", "0942400722", "photo.png", 1L });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreatedAt", "Email", "LastModifiedAt", "Password", "RoleId", "UserId", "Username" },
                values: new object[] { 1L, new DateTime(2022, 7, 14, 17, 16, 23, 301, DateTimeKind.Local).AddTicks(1738), "nhat@gmail.com", new DateTime(2022, 7, 14, 17, 16, 23, 301, DateTimeKind.Local).AddTicks(2056), "123", 1L, 1L, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShoppingCart_Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 14, 17, 11, 22, 980, DateTimeKind.Local).AddTicks(3626),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 14, 17, 16, 23, 298, DateTimeKind.Local).AddTicks(6025));
        }
    }
}
