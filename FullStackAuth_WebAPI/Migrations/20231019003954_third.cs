using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78adf75f-ca4a-42af-9a07-7adf1812f13e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a69cff7d-7b14-4f62-8ba6-9645b7b98a7a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c6b8fbf4-60c1-41ba-b76e-fc8cd2a37c68", null, "User", "USER" },
                    { "e34fc6f4-bcdf-46ae-8be7-45db99ae3388", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b8fbf4-60c1-41ba-b76e-fc8cd2a37c68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e34fc6f4-bcdf-46ae-8be7-45db99ae3388");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78adf75f-ca4a-42af-9a07-7adf1812f13e", null, "User", "USER" },
                    { "a69cff7d-7b14-4f62-8ba6-9645b7b98a7a", null, "Admin", "ADMIN" }
                });
        }
    }
}
