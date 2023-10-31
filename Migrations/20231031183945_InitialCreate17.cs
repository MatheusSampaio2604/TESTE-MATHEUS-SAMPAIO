using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaServicos_Supplier",
                table: "TBL_SolicitaServicos",
                column: "Supplier");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_SolicitaServicos_TBL_Fornecedores_Supplier",
                table: "TBL_SolicitaServicos",
                column: "Supplier",
                principalTable: "TBL_Fornecedores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_SolicitaServicos_TBL_Fornecedores_Supplier",
                table: "TBL_SolicitaServicos");

            migrationBuilder.DropIndex(
                name: "IX_TBL_SolicitaServicos_Supplier",
                table: "TBL_SolicitaServicos");
        }
    }
}
