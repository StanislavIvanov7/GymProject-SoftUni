using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class AddQuantityColumnInFitnessCardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FitnessCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Fitness card quantity");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 3, 20, 15, 40, 29, 275, DateTimeKind.Local).AddTicks(2715));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FitnessCards");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 3, 20, 15, 23, 52, 872, DateTimeKind.Local).AddTicks(8900));
        }
    }
}
