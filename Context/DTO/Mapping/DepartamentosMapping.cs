using TESTE_MATHEUS_SAMPAIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping
{
    public class DepartamentosMapping : IEntityTypeConfiguration<DepartamentosModel>
    {
        public void Configure(EntityTypeBuilder<DepartamentosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome).HasColumnName("Name");
        }
    }
}