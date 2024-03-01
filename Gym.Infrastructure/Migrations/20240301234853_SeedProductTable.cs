using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class SeedProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatorId", "Description", "ImageUrl", "Name", "Price", "ProductCategoryId" },
                values: new object[] { 1, "2a2dba3e-f9bf-4c83-83eb-fbd8af5f891c", "The best protein bar.High amount of proteins (18 grams).", "https://fitspo.zone/wp-content/uploads/2022/11/slim_choco_brownie_front.jpg", "Fit Spo Slim Bar", 3.50m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
