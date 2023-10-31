using TESTE_MATHEUS_SAMPAIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping
{
    public class SolicitaComprasMapping : IEntityTypeConfiguration<SolicitaComprasModel>
    {
        public void Configure(EntityTypeBuilder<SolicitaComprasModel> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.ProdutosModel).WithMany(x => x.SolicitaComprasModel).HasForeignKey(x => x.Id_Produto);
            builder.HasOne(x => x.FornecedoresModel).WithMany(x => x.SolicitaComprasModel).HasForeignKey(x => x.Id_Fornecedor);
            builder.HasOne(x => x.UsuariosModel).WithMany(x => x.SolicitaComprasModel).HasForeignKey(x => x.Id_Usuario);
            builder.HasOne(x => x.DepartamentosModel).WithMany(x => x.SolicitaComprasModel).HasForeignKey(x => x.Id_Departamento);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Codigo_Solicitacao).HasColumnName("Code_Request");
            builder.Property(x => x.CodigoGTIN).HasColumnName("CodeGTIN");
            builder.Property(x => x.Fabricante).HasColumnName("Manufacturer");
            builder.Property(x => x.Quantidade).HasColumnName("Amount");

            builder.Property(x => x.Id_Produto).HasColumnName("Product_Id");
            builder.Property(x => x.Id_Fornecedor).HasColumnName("Supplier_Id");
            builder.Property(x => x.Id_Usuario).HasColumnName("User_Id");
            builder.Property(x => x.Id_Departamento).HasColumnName("Department_Id");

            builder.Property(x => x.Ativo).HasDefaultValue(1).HasColumnName("Active");
        }
    }
}
