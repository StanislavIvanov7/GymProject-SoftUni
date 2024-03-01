using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class SeedDietTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "CreatorId", "Description", "DietCategoryId", "ImageUrl", "Title" },
                values: new object[] { 1, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c", "Breakfast: 1 boiled egg, 1 slice whole grain toast, 1/2 grapefruit, green tea. Snack: 1 small apple, 10 almonds. Lunch: Grilled chicken, mixed greens. Snack: Greek yogurt with berries. Dinner: Baked salmon, quinoa, asparagus.", 1, "https://www.fitterfly.com/blog/wp-content/uploads/2022/12/Step-by-Step-Diet-Plan-for-Weight-Loss-copy_11zon.webp", "The best diet for weight loss" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
