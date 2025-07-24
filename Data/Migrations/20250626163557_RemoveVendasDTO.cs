using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaSOFT.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVendasDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeMedicamento",
                table: "vendas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeMedicamento",
                table: "vendas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
