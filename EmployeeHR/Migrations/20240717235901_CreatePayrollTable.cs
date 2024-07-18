using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeHR.Migrations
{
    /// <inheritdoc />
    public partial class CreatePayrollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SSa",
                schema: "dbo",
                table: "Payrolls",
                newName: "SocialSecurityAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialSecurityAmount",
                schema: "dbo",
                table: "Payrolls",
                newName: "SSa");
        }
    }
}
