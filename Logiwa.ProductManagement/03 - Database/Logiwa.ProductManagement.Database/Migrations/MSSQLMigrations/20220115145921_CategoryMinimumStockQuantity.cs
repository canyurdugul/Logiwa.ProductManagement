using Microsoft.EntityFrameworkCore.Migrations;

namespace Logiwa.ProductManagement.Database.Migrations.MSSQLMigrations
{
    public partial class CategoryMinimumStockQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinimumStockQuantity",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumStockQuantity",
                table: "Categories");
        }
    }
}
