using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LI.Carrinho.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CARRINHO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CARRINHO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CARRINHO_TB_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_ITEM_CARRINHO",
                columns: table => new
                {
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCarrinho = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ITEM_CARRINHO", x => new { x.IdProduto, x.IdCarrinho });
                    table.ForeignKey(
                        name: "FK_TB_ITEM_CARRINHO_TB_CARRINHO_IdCarrinho",
                        column: x => x.IdCarrinho,
                        principalTable: "TB_CARRINHO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_ITEM_CARRINHO_TB_PRODUTOS_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CARRINHO_IdCliente",
                table: "TB_CARRINHO",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITEM_CARRINHO_IdCarrinho",
                table: "TB_ITEM_CARRINHO",
                column: "IdCarrinho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ITEM_CARRINHO");

            migrationBuilder.DropTable(
                name: "TB_CARRINHO");

            migrationBuilder.DropTable(
                name: "TB_PRODUTOS");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE");
        }
    }
}
