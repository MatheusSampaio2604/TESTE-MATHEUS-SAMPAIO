using TESTE_MATHEUS_SAMPAIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping
{
    public class UsuariosMapping : IEntityTypeConfiguration<UsuariosModel>
    {
        public void Configure(EntityTypeBuilder<UsuariosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.DepartamentosModel).WithMany(x => x.UsuariosModel).HasForeignKey(x => x.Departamento);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Matricula).HasColumnName("Registry");
            builder.Property(x => x.Nome).HasColumnName("Name");
            builder.Property(x => x.Departamento).HasColumnName("Id_Department");
            builder.Property(x => x.Ativo).HasDefaultValue(1).HasColumnName("Active");
        }
    }
}