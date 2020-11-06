using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AeroAPI.Migrations
{
    public partial class CriacaoInicialDoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataIda = table.Column<DateTime>(nullable: false),
                    DataVolta = table.Column<DateTime>(nullable: false),
                    LocalOrigemIdId = table.Column<int>(nullable: true),
                    LocalOrigemId1 = table.Column<int>(nullable: true),
                    LocalDestinoIdId = table.Column<int>(nullable: true),
                    LocalDestinoId1 = table.Column<int>(nullable: true),
                    NumeroParadas = table.Column<int>(nullable: false),
                    TempoIda = table.Column<TimeSpan>(nullable: false),
                    TempoVolta = table.Column<TimeSpan>(nullable: false),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalDestinoId1",
                        column: x => x.LocalDestinoId1,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalDestinoIdId",
                        column: x => x.LocalDestinoIdId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalOrigemId1",
                        column: x => x.LocalOrigemId1,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalOrigemIdId",
                        column: x => x.LocalOrigemIdId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VooId = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Poltrona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VooId",
                table: "Reservas",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_LocalDestinoId1",
                table: "Voos",
                column: "LocalDestinoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_LocalDestinoIdId",
                table: "Voos",
                column: "LocalDestinoIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_LocalOrigemId1",
                table: "Voos",
                column: "LocalOrigemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_LocalOrigemIdId",
                table: "Voos",
                column: "LocalOrigemIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Voos");

            migrationBuilder.DropTable(
                name: "Locais");
        }
    }
}
