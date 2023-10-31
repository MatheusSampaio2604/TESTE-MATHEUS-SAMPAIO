using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Delivery_Time",
                table: "TBL_Servicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<long>(
                name: "State_Registration",
                table: "TBL_Fornecedores",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Municipal_Registration",
                table: "TBL_Fornecedores",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CNPJ",
                table: "TBL_Fornecedores",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Delivery_Time",
                table: "TBL_Servicos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "State_Registration",
                table: "TBL_Fornecedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Municipal_Registration",
                table: "TBL_Fornecedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CNPJ",
                table: "TBL_Fornecedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
