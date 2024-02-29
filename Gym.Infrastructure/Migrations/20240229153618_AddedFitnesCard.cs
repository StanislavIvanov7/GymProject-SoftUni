using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class AddedFitnesCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitnessCardCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Fitness card category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Fitness card category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCardCategories", x => x.Id);
                },
                comment: "Fitnes card category table");

            migrationBuilder.CreateTable(
                name: "FitnessCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Fitness card identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessCardCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Fitness card category identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Fitness card price"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Fitness card description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Fitness card image url"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Fitness card creator identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessCards_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessCards_FitnessCardCategories_FitnessCardCategoryId",
                        column: x => x.FitnessCardCategoryId,
                        principalTable: "FitnessCardCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Fitness card table");

            migrationBuilder.CreateTable(
                name: "UsersFitnessCards",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    FitnessCardId = table.Column<int>(type: "int", nullable: false, comment: "Fitness card identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFitnessCards", x => new { x.FitnessCardId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersFitnessCards_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersFitnessCards_FitnessCards_FitnessCardId",
                        column: x => x.FitnessCardId,
                        principalTable: "FitnessCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Fitness card-user mapping table");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCards_CreatorId",
                table: "FitnessCards",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCards_FitnessCardCategoryId",
                table: "FitnessCards",
                column: "FitnessCardCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFitnessCards_UserId",
                table: "UsersFitnessCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersFitnessCards");

            migrationBuilder.DropTable(
                name: "FitnessCards");

            migrationBuilder.DropTable(
                name: "FitnessCardCategories");
        }
    }
}
