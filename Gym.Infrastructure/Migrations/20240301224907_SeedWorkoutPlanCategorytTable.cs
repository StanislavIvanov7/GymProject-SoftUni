using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class SeedWorkoutPlanCategorytTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutPlanCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Amateur" },
                    { 2, "Beginner" },
                    { 3, "Advanced" },
                    { 4, "Professional" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutPlanCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutPlanCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutPlanCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutPlanCategories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
