using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class SeedDietCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DietCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Weight loss" });

            migrationBuilder.InsertData(
                table: "DietCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Weight gain" });

            migrationBuilder.InsertData(
                table: "DietCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Weight maintenance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DietCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DietCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DietCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
