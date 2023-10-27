using TESTE_MATHEUS_SAMPAIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping
{
    public class ServicosMapping : IEntityTypeConfiguration<ServicosModel>
    {
        public void Configure(EntityTypeBuilder<ServicosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.FornecedoresModel).WithMany(x => x.ServicosModel).HasForeignKey(x => x.Fornecedor);
            
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome_Servico).HasColumnName("Name_Service");
            builder.Property(x => x.Descricao_Servico).HasColumnName("Service_Description");
            builder.Property(x => x.Prazo_Entrega).HasColumnName("Delivery_Time");
            builder.Property(x => x.Fornecedor).HasColumnName("Id_Provider");
        }
    }
}
