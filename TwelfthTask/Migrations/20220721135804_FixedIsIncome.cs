using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwelfthTask.Migrations
{
    public partial class FixedIsIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "FinancialOperations");

            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "IncomeExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "IncomeExpenses");

            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "FinancialOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
