using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class CreateBuyerFitnessCartMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyersFitnessCards",
                columns: table => new
                {
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer identifier"),
                    FitnessCardId = table.Column<int>(type: "int", nullable: false, comment: "Fitness card identifier"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Fitness card quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyersFitnessCards", x => new { x.FitnessCardId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_BuyersFitnessCards_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyersFitnessCards_FitnessCards_FitnessCardId",
                        column: x => x.FitnessCardId,
                        principalTable: "FitnessCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 4, 4, 12, 10, 20, 532, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.CreateIndex(
                name: "IX_BuyersFitnessCards_BuyerId",
                table: "BuyersFitnessCards",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyersFitnessCards");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 4, 2, 12, 24, 47, 713, DateTimeKind.Local).AddTicks(3334));
        }
    }
}
