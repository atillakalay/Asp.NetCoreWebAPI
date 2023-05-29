using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class mig_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "129722e4-d2fa-4a6d-8bed-858e62b3274d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49571f9d-1730-4bf3-9be1-aae7407e7d8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87a43984-b8ea-4613-9bd7-b0345aaa714e");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpireTime",
                table: "AspNetUsers",
                newName: "RefreshTokenExpiryTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88039f60-7a6d-4e53-92e8-feff79e19d97", "50adc26d-744a-44ff-9282-b3f4a2db95f1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ad746bc-cd2f-4ebb-aa7e-68e0c87c09ca", "c012c0fd-9439-4081-a380-9f1fb44a3a83", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed0f9537-7627-4a39-89e2-27a4edc87f71", "42292898-01e9-4b42-beb7-2fcdc59f97f3", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88039f60-7a6d-4e53-92e8-feff79e19d97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ad746bc-cd2f-4ebb-aa7e-68e0c87c09ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed0f9537-7627-4a39-89e2-27a4edc87f71");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                newName: "RefreshTokenExpireTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "129722e4-d2fa-4a6d-8bed-858e62b3274d", "03d1f7d9-f570-42fb-a039-1c2cfc8c0b78", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49571f9d-1730-4bf3-9be1-aae7407e7d8f", "51dbda07-a2ce-4436-ba9a-e6d8bd5e857a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87a43984-b8ea-4613-9bd7-b0345aaa714e", "01ffb954-57a4-4b8d-a35e-26c692453772", "Admin", "ADMIN" });
        }
    }
}
