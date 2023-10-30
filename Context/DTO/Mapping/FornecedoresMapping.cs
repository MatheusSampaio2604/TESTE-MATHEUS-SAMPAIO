using TESTE_MATHEUS_SAMPAIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping
{
    public class FornecedoresMapping : IEntityTypeConfiguration<FornecedoresModel>
    {
        public void Configure(EntityTypeBuilder<FornecedoresModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome_Fornecedor).HasColumnName("Name_Provider");
            builder.Property(x => x.Email_Fornecedor).HasColumnName("EMAIL");
            builder.Property(x => x.CNPJ).HasColumnName("CNPJ");
            builder.Property(x => x.Inscricao_Estadual).HasColumnName("State_Registration");
            builder.Property(x => x.Inscricao_Municipal).HasColumnName("Municipal_Registration");
            builder.Property(x => x.Ativo).HasDefaultValue(1).HasColumnName("Active");
        }
    }
}