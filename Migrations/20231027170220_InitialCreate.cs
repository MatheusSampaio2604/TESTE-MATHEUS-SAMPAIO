using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<int>(type: "int", nullable: false),
                    State_Registration = table.Column<int>(type: "int", nullable: false),
                    Municipal_Registration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_GTIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Minimum_Stock = table.Column<int>(type: "int", nullable: false),
                    Current_Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Usuarios_TBL_Departamentos_Id_Department",
                        column: x => x.Id_Department,
                        principalTable: "TBL_Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_Time = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_Provider = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Servicos_TBL_Fornecedores_Id_Provider",
                        column: x => x.Id_Provider,
                        principalTable: "TBL_Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Servicos_Id_Provider",
                table: "TBL_Servicos",
                column: "Id_Provider");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Usuarios_Id_Department",
                table: "TBL_Usuarios",
                column: "Id_Department");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Produtos");

            migrationBuilder.DropTable(
                name: "TBL_Servicos");

            migrationBuilder.DropTable(
                name: "TBL_Usuarios");

            migrationBuilder.DropTable(
                name: "TBL_Fornecedores");

            migrationBuilder.DropTable(
                name: "TBL_Departamentos");
        }
    }
}
