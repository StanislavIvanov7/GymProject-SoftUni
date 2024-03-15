using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class ChangedFitnessCardAndProductsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Product quantity");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMonths",
                table: "FitnessCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Fitness card duration");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuesDate",
                table: "FitnessCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Fitness card issues date");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FitnessCards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Fitness card name");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DurationInMonths", "ImageUrl", "IssuesDate", "Name" },
                values: new object[] { 1, "https://mymetalbusinesscard.com/wp-content/uploads/2022/10/Fitness-Cards-Blog-Images.jpg", new DateTime(2024, 3, 15, 16, 31, 43, 195, DateTimeKind.Local).AddTicks(3299), "Fitness card for men before 4pm." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DurationInMonths",
                table: "FitnessCards");

            migrationBuilder.DropColumn(
                name: "IssuesDate",
                table: "FitnessCards");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FitnessCards");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://png.pngtree.com/template/20211021/ourmid/pngtree-personal-fitness-trainer-black-business-card-image_708208.png");
        }
    }
}
