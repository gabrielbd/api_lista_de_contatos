using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAspNetAPI02.Data.Migrations
{
    public partial class AddContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    IDCONTATO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FOTO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.IDCONTATO);
                    table.ForeignKey(
                        name: "FK_CONTATO_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "IDUSUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_IDUSUARIO",
                table: "CONTATO",
                column: "IDUSUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATO");
        }
    }
}
