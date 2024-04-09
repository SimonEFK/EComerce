using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStore.App.Migrations
{
    public partial class orderSum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderSum",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderSum",
                table: "Orders");
        }
    }
}
