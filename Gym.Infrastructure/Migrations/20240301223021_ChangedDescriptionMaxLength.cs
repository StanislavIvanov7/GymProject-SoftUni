using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class ChangedDescriptionMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WorkoutPlans",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Workout plan description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Workout plan description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FoodItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Food item description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Food item description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FitnessCards",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Fitness card description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Fitness card description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Diet description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Diet description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WorkoutPlans",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Workout plan description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Workout plan description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FoodItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Food item description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Food item description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FitnessCards",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Fitness card description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Fitness card description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Diets",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Diet description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Diet description");
        }
    }
}
