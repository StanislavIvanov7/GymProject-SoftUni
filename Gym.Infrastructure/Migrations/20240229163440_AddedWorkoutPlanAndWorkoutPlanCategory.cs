using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class AddedWorkoutPlanAndWorkoutPlanCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutPlanCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Workout plan category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Workout plan category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlanCategories", x => x.Id);
                },
                comment: "Workout plan category table");

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Workout plan identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Workout plan name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Workout plan image url"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Workout plan description"),
                    WorkoutPlanCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Workout plan category identifier"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Workout plan creator identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlans_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutPlans_WorkoutPlanCategories_WorkoutPlanCategoryId",
                        column: x => x.WorkoutPlanCategoryId,
                        principalTable: "WorkoutPlanCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Workout plan table");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_CreatorId",
                table: "WorkoutPlans",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_WorkoutPlanCategoryId",
                table: "WorkoutPlans",
                column: "WorkoutPlanCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "WorkoutPlanCategories");
        }
    }
}
