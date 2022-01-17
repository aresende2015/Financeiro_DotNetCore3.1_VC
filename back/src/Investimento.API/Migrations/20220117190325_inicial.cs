using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investimento.API.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasseDeAtivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    Iantivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseDeAtivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    Inativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corretoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    Inativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    Inativo = table.Column<bool>(nullable: false),
                    ClasseDeAtivoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativos_ClasseDeAtivos_ClasseDeAtivoId",
                        column: x => x.ClasseDeAtivoId,
                        principalTable: "ClasseDeAtivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientesCorretoras",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    CorretoraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesCorretoras", x => new { x.ClienteId, x.CorretoraId });
                    table.ForeignKey(
                        name: "FK_ClientesCorretoras_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientesCorretoras_Corretoras_CorretoraId",
                        column: x => x.CorretoraId,
                        principalTable: "Corretoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 1, new DateTime(2022, 1, 17, 16, 3, 25, 393, DateTimeKind.Local).AddTicks(4181), "Caderneta de Poupança", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 2, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8543), "Títulos Públicos", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 3, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8628), "CDB", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 4, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8632), "LCI", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 5, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8634), "LCA", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 6, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8641), "Caixa", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 7, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8643), "Ações", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 8, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8645), "Fundos Imobiliários", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 9, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8650), "ETFs", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 10, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8654), "Opções", true });

            migrationBuilder.InsertData(
                table: "ClasseDeAtivos",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Iantivo" },
                values: new object[] { 11, new DateTime(2022, 1, 17, 16, 3, 25, 394, DateTimeKind.Local).AddTicks(8656), "Mercado Futuro", true });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Inativo" },
                values: new object[] { 1, new DateTime(2022, 1, 17, 16, 3, 25, 396, DateTimeKind.Local).AddTicks(5713), "Alex Quintes de Resende", true });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Inativo" },
                values: new object[] { 2, new DateTime(2022, 1, 17, 16, 3, 25, 396, DateTimeKind.Local).AddTicks(8306), "Caio Resende", true });

            migrationBuilder.InsertData(
                table: "Corretoras",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Inativo" },
                values: new object[] { 1, new DateTime(2022, 1, 17, 16, 3, 25, 396, DateTimeKind.Local).AddTicks(9036), "Clear", true });

            migrationBuilder.InsertData(
                table: "Corretoras",
                columns: new[] { "Id", "DataDeCriacao", "Descricao", "Inativo" },
                values: new object[] { 2, new DateTime(2022, 1, 17, 16, 3, 25, 397, DateTimeKind.Local).AddTicks(1634), "MyCap", true });

            migrationBuilder.InsertData(
                table: "Ativos",
                columns: new[] { "Id", "ClasseDeAtivoId", "DataDeCriacao", "Descricao", "Inativo" },
                values: new object[] { 3, 6, new DateTime(2022, 1, 17, 16, 3, 25, 396, DateTimeKind.Local).AddTicks(4975), "Dinheiro", true });

            migrationBuilder.InsertData(
                table: "Ativos",
                columns: new[] { "Id", "ClasseDeAtivoId", "DataDeCriacao", "Descricao", "Inativo" },
                values: new object[] { 1, 7, new DateTime(2022, 1, 17, 16, 3, 25, 396, DateTimeKind.Local).AddTicks(1641), "PETR4", true });

            migrationBuilder.InsertData(
                table: "Ativos",
                columns: new[] { "Id", "ClasseDeAtivoId", "DataDeCriacao", "Descricao", "Inativo" },
                values: new object[] { 2, 7, new DateTime(2022, 1, 17, 16, 3, 25, 396, DateTimeKind.Local).AddTicks(4890), "BBDC4", true });

            migrationBuilder.InsertData(
                table: "ClientesCorretoras",
                columns: new[] { "ClienteId", "CorretoraId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ClientesCorretoras",
                columns: new[] { "ClienteId", "CorretoraId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "ClientesCorretoras",
                columns: new[] { "ClienteId", "CorretoraId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_ClasseDeAtivoId",
                table: "Ativos",
                column: "ClasseDeAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesCorretoras_CorretoraId",
                table: "ClientesCorretoras",
                column: "CorretoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "ClientesCorretoras");

            migrationBuilder.DropTable(
                name: "ClasseDeAtivos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Corretoras");
        }
    }
}
