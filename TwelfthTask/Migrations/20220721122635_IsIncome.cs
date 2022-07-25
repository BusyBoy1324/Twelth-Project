using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwelfthTask.Migrations
{
    public partial class IsIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "FinancialOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "FinancialOperations");
        }
    }
}
