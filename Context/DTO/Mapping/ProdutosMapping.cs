using TESTE_MATHEUS_SAMPAIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping
{
    public class ProdutosMapping : IEntityTypeConfiguration<ProdutosModel>
    {
        public void Configure(EntityTypeBuilder<ProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome).HasColumnName("Name");
            builder.Property(x => x.CodigoGTIN).HasColumnName("Codigo_GTIN");
            builder.Property(x => x.Valor).HasColumnName("Value");
            builder.Property(x => x.Minimo_Estoque).HasColumnName("Minimum_Stock");
            builder.Property(x => x.Estoque_Atual).HasColumnName("Current_Stock");


        }
    }
}
