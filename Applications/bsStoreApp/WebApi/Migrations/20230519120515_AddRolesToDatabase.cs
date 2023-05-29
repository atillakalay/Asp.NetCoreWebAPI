using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0390bc74-b241-4e4e-8d29-d71b1a89afef", "1f341883-8690-4681-82db-3e0683cf1f2e", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2bbcf91f-a584-4d68-b847-33e3121395fc", "7c189b90-e708-4e84-b2fa-0a3c12efdacc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b80d9bf4-7253-48a6-b5d3-f8e7d1dfb2af", "57201f5c-5bea-49e3-94ed-da611f538c79", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0390bc74-b241-4e4e-8d29-d71b1a89afef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bbcf91f-a584-4d68-b847-33e3121395fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b80d9bf4-7253-48a6-b5d3-f8e7d1dfb2af");
        }
    }
}
