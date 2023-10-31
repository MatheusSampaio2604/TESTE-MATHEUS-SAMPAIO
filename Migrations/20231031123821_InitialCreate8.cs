using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_SolicitaPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code_Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeGTIN = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Supplier_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SolicitaPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_SolicitaPedidos_TBL_Departamentos_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "TBL_Departamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_SolicitaPedidos_TBL_Fornecedores_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "TBL_Fornecedores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_SolicitaPedidos_TBL_Produtos_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "TBL_Produtos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_SolicitaPedidos_TBL_Usuarios_User_Id",
                        column: x => x.User_Id,
                        principalTable: "TBL_Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_SolicitaServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Register = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Supplier = table.Column<int>(type: "int", nullable: false),
                    Type_Service = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SolicitaServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_SolicitaServicos_TBL_Departamentos_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "TBL_Departamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_SolicitaServicos_TBL_Servicos_Type_Service",
                        column: x => x.Type_Service,
                        principalTable: "TBL_Servicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_SolicitaServicos_TBL_Usuarios_User_Id",
                        column: x => x.User_Id,
                        principalTable: "TBL_Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaPedidos_Department_Id",
                table: "TBL_SolicitaPedidos",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaPedidos_Product_Id",
                table: "TBL_SolicitaPedidos",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaPedidos_Supplier_Id",
                table: "TBL_SolicitaPedidos",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaPedidos_User_Id",
                table: "TBL_SolicitaPedidos",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaServicos_Department_Id",
                table: "TBL_SolicitaServicos",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaServicos_Type_Service",
                table: "TBL_SolicitaServicos",
                column: "Type_Service");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SolicitaServicos_User_Id",
                table: "TBL_SolicitaServicos",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_SolicitaPedidos");

            migrationBuilder.DropTable(
                name: "TBL_SolicitaServicos");
        }
    }
}
