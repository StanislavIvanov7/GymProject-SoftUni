using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class AddedQuantityColumnInUserFitnessCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "UsersProducts",
                type: "int",
                nullable: false,
                comment: "Product quantity",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UsersFitnessCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Fitness card quantity");

   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UsersFitnessCards");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "UsersProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Product quantity");

       
        }
    }
}
