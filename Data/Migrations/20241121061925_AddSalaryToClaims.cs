using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10140587_Prog6212_Part2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryToClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Claims",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Claims");
        }
    }
}
