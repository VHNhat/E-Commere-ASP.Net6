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
                defaultValue: new DateTime(2022, 7, 20, 9, 17, 40, 3, DateTimeKind.Local).AddTicks(8201),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 20, 9, 17, 21, 707, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[] { 1L, new DateTime(2022, 7, 20, 9, 17, 40, 8, DateTimeKind.Local).AddTicks(1740), new DateTime(2022, 7, 20, 9, 17, 40, 8, DateTimeKind.Local).AddTicks(1741), "admin" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "Address", "CreatedAt", "Detail", "LastModifiedAt", "Map", "Name", "Photo" },
                values: new object[] { 1L, "Đặng Thùy Trâm", new DateTime(2022, 7, 20, 9, 17, 40, 8, DateTimeKind.Local).AddTicks(5619), "cc", new DateTime(2022, 7, 20, 9, 17, 40, 8, DateTimeKind.Local).AddTicks(5620), "cc", "Unny mini house", "photo.png" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccountId", "CreatedAt", "FullName", "Gender", "LastModifiedAt", "Phone", "Photo", "StoreId" },
                values: new object[] { 1L, 1L, new DateTime(2022, 7, 20, 9, 17, 40, 8, DateTimeKind.Local).AddTicks(2790), "Võ Hoàng Nhật", 1, new DateTime(2022, 7, 20, 9, 17, 40, 8, DateTimeKind.Local).AddTicks(2791), "0942400722", "photo.png", 1L });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreatedAt", "Email", "LastModifiedAt", "Password", "RoleId", "UserId", "Username" },
                values: new object[] { 1L, new DateTime(2022, 7, 20, 9, 17, 40, 6, DateTimeKind.Local).AddTicks(7663), "nhat@gmail.com", new DateTime(2022, 7, 20, 9, 17, 40, 6, DateTimeKind.Local).AddTicks(8044), "123", 1L, 1L, "admin" });
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
                defaultValue: new DateTime(2022, 7, 20, 9, 17, 21, 707, DateTimeKind.Local).AddTicks(1151),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 7, 20, 9, 17, 40, 3, DateTimeKind.Local).AddTicks(8201));
        }
    }
}
