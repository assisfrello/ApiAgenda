using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgenda.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgendaInclusaoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Agenda",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Agenda",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Agenda",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AgendaContato",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(type: "integer", nullable: false),
                    Celular = table.Column<string>(type: "varchar(15)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaContato", x => x.IdAgenda);
                    table.ForeignKey(
                        name: "FK_AgendaContato_Agenda_IdAgenda",
                        column: x => x.IdAgenda,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaEndereco",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(type: "integer", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(8)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaEndereco", x => x.IdAgenda);
                    table.ForeignKey(
                        name: "FK_AgendaEndereco_Agenda_IdAgenda",
                        column: x => x.IdAgenda,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaContato");

            migrationBuilder.DropTable(
                name: "AgendaEndereco");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Agenda");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Agenda",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Agenda",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
