using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planningame_Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class votoPk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Votos",
                table: "Votos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votos",
                table: "Votos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_JogadorId",
                table: "Votos",
                column: "JogadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Votos",
                table: "Votos");

            migrationBuilder.DropIndex(
                name: "IX_Votos_JogadorId",
                table: "Votos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votos",
                table: "Votos",
                columns: new[] { "JogadorId", "RodadaId" });
        }
    }
}
