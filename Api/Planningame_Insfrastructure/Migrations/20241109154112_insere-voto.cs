using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planningame_Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inserevoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voto",
                columns: table => new
                {
                    JogadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    RodadaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Valor = table.Column<int>(type: "integer", nullable: false),
                    DataDoVoto = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voto", x => new { x.JogadorId, x.RodadaId });
                    table.ForeignKey(
                        name: "FK_Voto_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voto_Rodadas_RodadaId",
                        column: x => x.RodadaId,
                        principalTable: "Rodadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voto_RodadaId",
                table: "Voto",
                column: "RodadaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voto");
        }
    }
}
