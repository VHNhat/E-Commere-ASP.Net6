using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[] { 1L, new DateTime(2022, 7, 24, 18, 55, 11, 779, DateTimeKind.Local).AddTicks(3864), new DateTime(2022, 7, 24, 18, 55, 11, 779, DateTimeKind.Local).AddTicks(3865), "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccountId", "Avatar", "CreatedAt", "FullName", "Gender", "LastModifiedAt", "OrganizerId", "Phone" },
                values: new object[] { 1L, 1L, "photo.png", new DateTime(2022, 7, 24, 18, 55, 11, 779, DateTimeKind.Local).AddTicks(5057), "Võ Hoàng Nhật", 1, new DateTime(2022, 7, 24, 18, 55, 11, 779, DateTimeKind.Local).AddTicks(5058), 1L, "0942400722" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreatedAt", "Email", "LastModifiedAt", "Password", "RoleId", "UserId", "Username" },
                values: new object[] { 1L, new DateTime(2022, 7, 24, 18, 55, 11, 777, DateTimeKind.Local).AddTicks(6616), "nhat@gmail.com", new DateTime(2022, 7, 24, 18, 55, 11, 777, DateTimeKind.Local).AddTicks(7164), "123", 1L, 1L, "admin" });

            migrationBuilder.InsertData(
                table: "Organizer",
                columns: new[] { "Id", "Address", "CreatedAt", "Detail", "Email", "IsCompany", "LastModifiedAt", "Name", "Phone", "Photo", "UserId" },
                values: new object[] { 1L, "address", new DateTime(2022, 7, 24, 18, 55, 11, 779, DateTimeKind.Local).AddTicks(8148), "detail", "email@gmail.com", true, new DateTime(2022, 7, 24, 18, 55, 11, 779, DateTimeKind.Local).AddTicks(8149), "name", "0900000000", "photo", 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Organizer",
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
        }
    }
}
