using Microsoft.EntityFrameworkCore.Migrations;

namespace Logiwa.ProductManagement.Database.Migrations.PostgreSQLMigrations
{
    public partial class CategoryMinimumStockQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinimumStockQuantity",
                schema: "product-management",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumStockQuantity",
                schema: "product-management",
                table: "Categories");
        }
    }
}
