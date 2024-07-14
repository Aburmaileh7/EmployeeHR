using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeHR.Migrations
{
    /// <inheritdoc />
    public partial class basicsalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                schema: "dbo",
                table: "Employees",
                newName: "BasicSalary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                schema: "dbo",
                table: "Employees",
                newName: "BasicSalary");
        }
    }
}
