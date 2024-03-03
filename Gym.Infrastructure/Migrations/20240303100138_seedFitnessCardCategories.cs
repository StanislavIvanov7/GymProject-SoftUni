using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class seedFitnessCardCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FitnessCardCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Group training" },
                    { 2, "Individual training" },
                    { 3, "Until 4pm. for men" },
                    { 4, "Until 4pm. for girls" },
                    { 5, "Unlimited access for men" },
                    { 6, "Unlimited access for girls" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FitnessCardCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FitnessCardCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FitnessCardCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FitnessCardCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FitnessCardCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FitnessCardCategories",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
