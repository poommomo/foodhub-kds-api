using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHub.Migrations
{
    public partial class orderinfovoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "OrderInformations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "OrderInformations");
        }
    }
}
