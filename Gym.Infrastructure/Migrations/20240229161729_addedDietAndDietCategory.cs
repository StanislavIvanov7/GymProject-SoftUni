using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class addedDietAndDietCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Diet category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Diet category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietCategories", x => x.Id);
                },
                comment: "Diet category table");

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Diet identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false, comment: "Diet title"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Diet description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Diet image url"),
                    DietCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Diet category identifier"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Diet creator identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_DietCategories_DietCategoryId",
                        column: x => x.DietCategoryId,
                        principalTable: "DietCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Diet table");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_CreatorId",
                table: "Diets",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_DietCategoryId",
                table: "Diets",
                column: "DietCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "DietCategories");
        }
    }
}
