﻿// <auto-generated />
using System;
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
    [Migration("20231031180045_InitialCreate15")]
    partial class InitialCreate15
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

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

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
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Inscricao_Estadual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("State_Registration");

                    b.Property<string>("Inscricao_Municipal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Municipal_Registration");

                    b.Property<string>("Nome")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code_GTIN");

                    b.Property<string>("Estoque_Atual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Service_Description");

                    b.Property<int>("Fornecedor")
                        .HasColumnType("int")
                        .HasColumnName("Id_Provider");

                    b.Property<string>("Nome_Servico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name_Service");

                    b.Property<int>("Prazo_Entrega")
                        .HasColumnType("int")
                        .HasColumnName("Delivery_Time");

                    b.HasKey("Id");

                    b.HasIndex("Fornecedor");

                    b.ToTable("TBL_Servicos");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.SolicitaComprasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

                    b.Property<string>("CodigoGTIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CodeGTIN");

                    b.Property<string>("Codigo_Solicitacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code_Request");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Manufacturer");

                    b.Property<int>("Id_Departamento")
                        .HasColumnType("int")
                        .HasColumnName("Department_Id");

                    b.Property<int>("Id_Fornecedor")
                        .HasColumnType("int")
                        .HasColumnName("Supplier_Id");

                    b.Property<int>("Id_Produto")
                        .HasColumnType("int")
                        .HasColumnName("Product_Id");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.HasKey("Id");

                    b.HasIndex("Id_Departamento");

                    b.HasIndex("Id_Fornecedor");

                    b.HasIndex("Id_Produto");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("TBL_SolicitaPedidos");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.SolicitaServicosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

                    b.Property<DateTime>("Data_Cadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_Register");

                    b.Property<int>("Fornecedor")
                        .HasColumnType("int")
                        .HasColumnName("Supplier");

                    b.Property<int>("Id_Departamento")
                        .HasColumnType("int")
                        .HasColumnName("Department_Id");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observation");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int")
                        .HasColumnName("Type_Service");

                    b.HasKey("Id");

                    b.HasIndex("Id_Departamento");

                    b.HasIndex("Id_Usuario");

                    b.HasIndex("TipoServico");

                    b.ToTable("TBL_SolicitaServicos");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.UsuariosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Active");

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
                        .IsRequired();

                    b.Navigation("FornecedoresModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.SolicitaComprasModel", b =>
                {
                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel", "DepartamentosModel")
                        .WithMany("SolicitaComprasModel")
                        .HasForeignKey("Id_Departamento")
                        .IsRequired();

                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.FornecedoresModel", "FornecedoresModel")
                        .WithMany("SolicitaComprasModel")
                        .HasForeignKey("Id_Fornecedor")
                        .IsRequired();

                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.ProdutosModel", "ProdutosModel")
                        .WithMany("SolicitaComprasModel")
                        .HasForeignKey("Id_Produto")
                        .IsRequired();

                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.UsuariosModel", "UsuariosModel")
                        .WithMany("SolicitaComprasModel")
                        .HasForeignKey("Id_Usuario")
                        .IsRequired();

                    b.Navigation("DepartamentosModel");

                    b.Navigation("FornecedoresModel");

                    b.Navigation("ProdutosModel");

                    b.Navigation("UsuariosModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.SolicitaServicosModel", b =>
                {
                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel", "DepartamentosModel")
                        .WithMany("SolicitaServicosModel")
                        .HasForeignKey("Id_Departamento")
                        .IsRequired();

                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.UsuariosModel", "UsuariosModel")
                        .WithMany("SolicitaServicosModel")
                        .HasForeignKey("Id_Usuario")
                        .IsRequired();

                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.ServicosModel", "ServicosModel")
                        .WithMany("SolicitaServicosModel")
                        .HasForeignKey("TipoServico")
                        .IsRequired();

                    b.Navigation("DepartamentosModel");

                    b.Navigation("ServicosModel");

                    b.Navigation("UsuariosModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.UsuariosModel", b =>
                {
                    b.HasOne("TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel", "DepartamentosModel")
                        .WithMany("UsuariosModel")
                        .HasForeignKey("Departamento")
                        .IsRequired();

                    b.Navigation("DepartamentosModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel", b =>
                {
                    b.Navigation("SolicitaComprasModel");

                    b.Navigation("SolicitaServicosModel");

                    b.Navigation("UsuariosModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.FornecedoresModel", b =>
                {
                    b.Navigation("ServicosModel");

                    b.Navigation("SolicitaComprasModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.ProdutosModel", b =>
                {
                    b.Navigation("SolicitaComprasModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.ServicosModel", b =>
                {
                    b.Navigation("SolicitaServicosModel");
                });

            modelBuilder.Entity("TESTE_MATHEUS_SAMPAIO.Models.UsuariosModel", b =>
                {
                    b.Navigation("SolicitaComprasModel");

                    b.Navigation("SolicitaServicosModel");
                });
#pragma warning restore 612, 618
        }
    }
}
