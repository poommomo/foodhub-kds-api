using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHub.Migrations
{
    public partial class Changemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Table",
                table: "OrderInformations");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "OrderInformations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_OrderInformations_LocationId",
                table: "OrderInformations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInformations_Locations_LocationId",
                table: "OrderInformations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInformations_Locations_LocationId",
                table: "OrderInformations");

            migrationBuilder.DropIndex(
                name: "IX_OrderInformations_LocationId",
                table: "OrderInformations");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "OrderInformations");

            migrationBuilder.AddColumn<string>(
                name: "Table",
                table: "OrderInformations",
                nullable: true);
        }
    }
}
