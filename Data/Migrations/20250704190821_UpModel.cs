using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaSOFT.Migrations
{
    /// <inheritdoc />
    public partial class UpModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venda_clientes_ClienteId",
                table: "venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_venda",
                table: "venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produtos",
                table: "produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "venda",
                newName: "Venda");

            migrationBuilder.RenameTable(
                name: "produtos",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_venda_ClienteId",
                table: "Venda",
                newName: "IX_Venda_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venda",
                table: "Venda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Clientes_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Clientes_ClienteId",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venda",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Venda",
                newName: "venda");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "produtos");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ClienteId",
                table: "venda",
                newName: "IX_venda_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_venda",
                table: "venda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produtos",
                table: "produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_venda_clientes_ClienteId",
                table: "venda",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id");
        }
    }
}
