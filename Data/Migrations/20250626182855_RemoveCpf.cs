using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaSOFT.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfCliente",
                table: "venda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CpfCliente",
                table: "venda",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
