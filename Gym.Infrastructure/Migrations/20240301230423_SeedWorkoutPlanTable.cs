using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class SeedWorkoutPlanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "CreatorId", "Description", "ImageUrl", "Name", "WorkoutPlanCategoryId" },
                values: new object[] { 1, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c", "first day-chest and arms, second day-back and shoulder, third day-legs, fourth day-rest", "https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2016/09/Bodybuilder-Working-Out-His-Upper-Body-With-Cable-Crossover-Exercise.jpg?quality=86&strip=all", "The best workout plan for begginar", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
