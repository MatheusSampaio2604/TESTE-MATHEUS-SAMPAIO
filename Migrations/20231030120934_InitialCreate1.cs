using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TBL_Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TBL_Fornecedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TBL_Departamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TBL_Usuarios");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "TBL_Fornecedores");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "TBL_Departamentos");
        }
    }
}
