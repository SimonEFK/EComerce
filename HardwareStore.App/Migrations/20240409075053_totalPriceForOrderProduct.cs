using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStore.App.Migrations
{
    public partial class totalPriceForOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "OrdersProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "OrdersProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "OrdersProducts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrdersProducts");
        }
    }
}
