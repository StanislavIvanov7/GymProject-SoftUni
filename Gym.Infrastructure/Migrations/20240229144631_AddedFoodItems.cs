using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class AddedFoodItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Food item category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Food item category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemCategories", x => x.Id);
                },
                comment: "Food item category table");

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Food item identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Food item name"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Food item price"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Food item description"),
                    FoodItemCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Food item category identifier"),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Food item creator identifier"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Food item image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItems_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItems_FoodItemCategories_FoodItemCategoryId",
                        column: x => x.FoodItemCategoryId,
                        principalTable: "FoodItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Food item table");

            migrationBuilder.CreateTable(
                name: "UsersFoodItems",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false, comment: "Food item identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFoodItems", x => new { x.UserId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_UsersFoodItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersFoodItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Users and food items mapping table");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CreatorId",
                table: "FoodItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_FoodItemCategoryId",
                table: "FoodItems",
                column: "FoodItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFoodItems_FoodItemId",
                table: "UsersFoodItems",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersFoodItems");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "FoodItemCategories");
        }
    }
}
