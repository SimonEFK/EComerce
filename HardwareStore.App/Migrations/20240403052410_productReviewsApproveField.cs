using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStore.App.Migrations
{
    public partial class productReviewsApproveField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ProductReviews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ProductReviews");
        }
    }
}
