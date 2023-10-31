using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CodeGTIN",
                table: "TBL_SolicitaPedidos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Service_Description",
                table: "TBL_Servicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_Service",
                table: "TBL_Servicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Current_Stock",
                table: "TBL_Produtos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Code_GTIN",
                table: "TBL_Produtos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CodeGTIN",
                table: "TBL_SolicitaPedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Service_Description",
                table: "TBL_Servicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name_Service",
                table: "TBL_Servicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Current_Stock",
                table: "TBL_Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Code_GTIN",
                table: "TBL_Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
