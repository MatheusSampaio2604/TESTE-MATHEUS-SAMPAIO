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
            builder.Property(x => x.Nome_Fornecedor).HasColumnName("Name_Provider");
            builder.Property(x => x.Email_Fornecedor).HasColumnName("EMAIL");
            builder.Property(x => x.CNPJ).HasColumnName("CNPJ");
            builder.Property(x => x.Inscricao_Estadual).HasColumnName("State_Registration");
            builder.Property(x => x.Inscricao_Municipal).HasColumnName("Municipal_Registration");
        }
    }
}

/*

        [Column("EMAIL")]
        public string? Email_Fornecedor { get; set; }

        [Column("CNPJ")]
        public int CNPJ { get; set; }

        [Column("State_Registration")]
        public int Inscricao_Estadual { get; set; }

        [Column("Municipal_Registration")]
        public int Inscricao_Municipal { get; set; }

        public virtual ICollection<ServicosModel>? ServicosModel { get; set; }
*/