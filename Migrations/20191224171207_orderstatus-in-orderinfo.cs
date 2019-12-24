using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHub.Migrations
{
    public partial class orderstatusinorderinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "OrderInformations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "OrderInformations");
        }
    }
}
