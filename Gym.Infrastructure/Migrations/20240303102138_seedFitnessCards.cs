using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class seedFitnessCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FitnessCards",
                columns: new[] { "Id", "CreatorId", "Description", "FitnessCardCategoryId", "ImageUrl", "Price" },
                values: new object[] { 1, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c", "You have access to the gym every day before 4pm. The duration of this card is 1 month.", 3, "https://png.pngtree.com/template/20211021/ourmid/pngtree-personal-fitness-trainer-black-business-card-image_708208.png", 40m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
