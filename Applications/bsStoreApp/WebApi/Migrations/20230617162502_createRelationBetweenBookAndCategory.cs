using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class createRelationBetweenBookAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "607f7c85-356a-406f-800a-1d29c1e63925");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc5065dd-642e-4615-82f1-b3ee345534ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f7c7c5-2e92-4525-974c-037909e9a969");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bff39a6-74bd-4b19-9302-0a55d1a1dafd", "206c065b-a1da-487f-ad55-3c5126f05c8f", "User", "USER" },
                    { "c7ade1ec-e72a-4525-8a9a-7dff68c22164", "6f6eda3f-0e85-483f-ad26-48a560bca18f", "Editor", "EDITOR" },
                    { "e0272947-dec4-4698-aa25-0b83b69238a0", "135283df-7285-4c9c-9f4e-686d61847b8d", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bff39a6-74bd-4b19-9302-0a55d1a1dafd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ade1ec-e72a-4525-8a9a-7dff68c22164");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0272947-dec4-4698-aa25-0b83b69238a0");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "607f7c85-356a-406f-800a-1d29c1e63925", "3a03f06b-8aa3-4978-9aa3-00f6e253f1cf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc5065dd-642e-4615-82f1-b3ee345534ce", "58a08d19-e6fb-4214-a526-853788be21b1", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4f7c7c5-2e92-4525-974c-037909e9a969", "6f474d2e-d0e8-4b14-95b3-238ece51b348", "Admin", "ADMIN" });
        }
    }
}
