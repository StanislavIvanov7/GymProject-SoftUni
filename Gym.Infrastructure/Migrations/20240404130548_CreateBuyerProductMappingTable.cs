using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Infrastructure.Migrations
{
    public partial class CreateBuyerProductMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "BuyersFitnessCards",
                comment: "Buyer Fitness Card Mapping Table");

            migrationBuilder.CreateTable(
                name: "BuyersProducts",
                columns: table => new
                {
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer identifier"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Fitness card identifier"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Product quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyersProducts", x => new { x.ProductId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_BuyersProducts_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Buyer Product Mapping Table");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 4, 4, 16, 5, 48, 340, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.CreateIndex(
                name: "IX_BuyersProducts_BuyerId",
                table: "BuyersProducts",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyersProducts");

            migrationBuilder.AlterTable(
                name: "BuyersFitnessCards",
                oldComment: "Buyer Fitness Card Mapping Table");

            migrationBuilder.UpdateData(
                table: "FitnessCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuesDate",
                value: new DateTime(2024, 4, 4, 12, 10, 20, 532, DateTimeKind.Local).AddTicks(8136));
        }
    }
}
