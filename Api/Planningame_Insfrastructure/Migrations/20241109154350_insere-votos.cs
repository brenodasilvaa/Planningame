using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planningame_Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inserevotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voto_Jogadores_JogadorId",
                table: "Voto");

            migrationBuilder.DropForeignKey(
                name: "FK_Voto_Rodadas_RodadaId",
                table: "Voto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voto",
                table: "Voto");

            migrationBuilder.RenameTable(
                name: "Voto",
                newName: "Votos");

            migrationBuilder.RenameIndex(
                name: "IX_Voto_RodadaId",
                table: "Votos",
                newName: "IX_Votos_RodadaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votos",
                table: "Votos",
                columns: new[] { "JogadorId", "RodadaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Jogadores_JogadorId",
                table: "Votos",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Rodadas_RodadaId",
                table: "Votos",
                column: "RodadaId",
                principalTable: "Rodadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Jogadores_JogadorId",
                table: "Votos");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Rodadas_RodadaId",
                table: "Votos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votos",
                table: "Votos");

            migrationBuilder.RenameTable(
                name: "Votos",
                newName: "Voto");

            migrationBuilder.RenameIndex(
                name: "IX_Votos_RodadaId",
                table: "Voto",
                newName: "IX_Voto_RodadaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voto",
                table: "Voto",
                columns: new[] { "JogadorId", "RodadaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Voto_Jogadores_JogadorId",
                table: "Voto",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voto_Rodadas_RodadaId",
                table: "Voto",
                column: "RodadaId",
                principalTable: "Rodadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
