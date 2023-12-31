﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TESTE_MATHEUS_SAMPAIO.Context;

#nullable disable

namespace TESTE_MATHEUS_SAMPAIO.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231027170220_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("TBL_Departamentos");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.FornecedoresModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CNPJ")
                        .HasColumnType("int")
                        .HasColumnName("CNPJ");

                    b.Property<string>("Email_Fornecedor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<int>("Inscricao_Estadual")
                        .HasColumnType("int")
                        .HasColumnName("State_Registration");

                    b.Property<int>("Inscricao_Municipal")
                        .HasColumnType("int")
                        .HasColumnName("Municipal_Registration");

                    b.Property<string>("Nome_Fornecedor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name_Provider");

                    b.HasKey("Id");

                    b.ToTable("TBL_Fornecedores");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.ProdutosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoGTIN")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Codigo_GTIN");

                    b.Property<int>("Estoque_Atual")
                        .HasColumnType("int")
                        .HasColumnName("Current_Stock");

                    b.Property<int>("Minimo_Estoque")
                        .HasColumnType("int")
                        .HasColumnName("Minimum_Stock");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("TBL_Produtos");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.ServicosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao_Servico")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Service_Description");

                    b.Property<int>("Fornecedor")
                        .HasColumnType("int")
                        .HasColumnName("Id_Provider");

                    b.Property<string>("Nome_Servico")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name_Service");

                    b.Property<decimal>("Prazo_Entrega")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Delivery_Time");

                    b.HasKey("Id");

                    b.HasIndex("Fornecedor");

                    b.ToTable("TBL_Servicos");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.UsuariosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Departamento")
                        .HasColumnType("int")
                        .HasColumnName("Id_Department");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Registry");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Departamento");

                    b.ToTable("TBL_Usuarios");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.ServicosModel", b =>
                {
                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.FornecedoresModel", "FornecedoresModel")
                        .WithMany("ServicosModel")
                        .HasForeignKey("Fornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FornecedoresModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.UsuariosModel", b =>
                {
                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel", "DepartamentosModel")
                        .WithMany("UsuariosModel")
                        .HasForeignKey("Departamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartamentosModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel", b =>
                {
                    b.Navigation("UsuariosModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.FornecedoresModel", b =>
                {
                    b.Navigation("ServicosModel");
                });
#pragma warning restore 612, 618
        }
    }
}
