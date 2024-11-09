using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planningame_Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PartidaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogadores_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rodadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    PartidaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rodadas_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JogadorRodada",
                columns: table => new
                {
                    JogadoresId = table.Column<Guid>(type: "uuid", nullable: false),
                    RodadasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogadorRodada", x => new { x.JogadoresId, x.RodadasId });
                    table.ForeignKey(
                        name: "FK_JogadorRodada_Jogadores_JogadoresId",
                        column: x => x.JogadoresId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogadorRodada_Rodadas_RodadasId",
                        column: x => x.RodadasId,
                        principalTable: "Rodadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_PartidaId",
                table: "Jogadores",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_JogadorRodada_RodadasId",
                table: "JogadorRodada",
                column: "RodadasId");

            migrationBuilder.CreateIndex(
                name: "IX_Rodadas_PartidaId",
                table: "Rodadas",
                column: "PartidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogadorRodada");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Rodadas");

            migrationBuilder.DropTable(
                name: "Partidas");
        }
    }
}
