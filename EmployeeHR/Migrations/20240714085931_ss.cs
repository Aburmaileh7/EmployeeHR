using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeHR.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSalary",
                schema: "dbo",
                table: "Payrolls",
                newName: "NetSalary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NetSalary",
                schema: "dbo",
                table: "Payrolls",
                newName: "TotalSalary");
        }
    }
}
