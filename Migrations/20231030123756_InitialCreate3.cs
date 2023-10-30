using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Suppliers",
                table: "TBL_Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Produtos_Id_Suppliers",
                table: "TBL_Produtos",
                column: "Id_Suppliers");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Produtos_TBL_Fornecedores_Id_Suppliers",
                table: "TBL_Produtos",
                column: "Id_Suppliers",
                principalTable: "TBL_Fornecedores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Produtos_TBL_Fornecedores_Id_Suppliers",
                table: "TBL_Produtos");

            migrationBuilder.DropIndex(
                name: "IX_TBL_Produtos_Id_Suppliers",
                table: "TBL_Produtos");

            migrationBuilder.DropColumn(
                name: "Id_Suppliers",
                table: "TBL_Produtos");
        }
    }
}
