using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations
{
    public partial class I3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Unit_Price",
                table: "PRODUCTS",
                type: "decimal(18,2)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Selling_Amount",
                table: "PRODUCTS",
                type: "decimal(18,2)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Unit_Price",
                table: "PRODUCTS",
                type: "int",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "Total_Selling_Amount",
                table: "PRODUCTS",
                type: "int",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 30);
        }
    }
}
