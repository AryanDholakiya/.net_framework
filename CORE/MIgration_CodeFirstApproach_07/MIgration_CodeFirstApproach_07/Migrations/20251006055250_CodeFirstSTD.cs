using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIgration_CodeFirstApproach_07.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstSTD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Std",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Std",
                table: "students");
        }
    }
}
