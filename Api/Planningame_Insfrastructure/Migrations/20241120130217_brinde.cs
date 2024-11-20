using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planningame_Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class brinde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Brindou",
                table: "Rodadas",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brindou",
                table: "Rodadas");
        }
    }
}
