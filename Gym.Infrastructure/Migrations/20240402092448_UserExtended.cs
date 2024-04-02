using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IssuesDate", "Quantity" },
                values: new object[] { new DateTime(2024, 4, 2, 12, 24, 47, 713, DateTimeKind.Local).AddTicks(3334), 50 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IssuesDate", "Quantity" },
                values: new object[] { new DateTime(2024, 3, 20, 15, 40, 29, 275, DateTimeKind.Local).AddTicks(2715), 0 });
        }
    }
}
