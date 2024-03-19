using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class AddQuantityToUserProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UsersProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 3, 19, 16, 53, 5, 138, DateTimeKind.Local).AddTicks(4874));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UsersProducts");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 3, 15, 16, 31, 43, 195, DateTimeKind.Local).AddTicks(3299));
        }
    }
}
