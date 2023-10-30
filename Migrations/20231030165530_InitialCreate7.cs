using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Produtos_TBL_Fornecedores_Id_Suppliers",
                table: "TBL_Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Servicos_TBL_Fornecedores_Id_Provider",
                table: "TBL_Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Usuarios_TBL_Departamentos_Id_Department",
                table: "TBL_Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_TBL_Produtos_Id_Suppliers",
                table: "TBL_Produtos");

            migrationBuilder.DropColumn(
                name: "Id_Suppliers",
                table: "TBL_Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "Code_GTIN",
                table: "TBL_Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Servicos_TBL_Fornecedores_Id_Provider",
                table: "TBL_Servicos",
                column: "Id_Provider",
                principalTable: "TBL_Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Usuarios_TBL_Departamentos_Id_Department",
                table: "TBL_Usuarios",
                column: "Id_Department",
                principalTable: "TBL_Departamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Servicos_TBL_Fornecedores_Id_Provider",
                table: "TBL_Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Usuarios_TBL_Departamentos_Id_Department",
                table: "TBL_Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Code_GTIN",
                table: "TBL_Produtos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Servicos_TBL_Fornecedores_Id_Provider",
                table: "TBL_Servicos",
                column: "Id_Provider",
                principalTable: "TBL_Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Usuarios_TBL_Departamentos_Id_Department",
                table: "TBL_Usuarios",
                column: "Id_Department",
                principalTable: "TBL_Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
