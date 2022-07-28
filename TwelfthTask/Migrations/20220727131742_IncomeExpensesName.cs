using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwelfthTask.Migrations
{
    public partial class IncomeExpensesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncomeExpensesName",
                table: "FinancialOperations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomeExpensesName",
                table: "FinancialOperations");
        }
    }
}
