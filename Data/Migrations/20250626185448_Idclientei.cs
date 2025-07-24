using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaSOFT.Migrations
{
    /// <inheritdoc />
    public partial class Idclientei : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venda_clientes_ClienteId",
                table: "venda");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "venda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_venda_clientes_ClienteId",
                table: "venda",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venda_clientes_ClienteId",
                table: "venda");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "venda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_venda_clientes_ClienteId",
                table: "venda",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
