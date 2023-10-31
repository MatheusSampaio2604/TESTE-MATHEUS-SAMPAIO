using TESTE_MATHEUS_SAMPAIO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping
{
    public class SolicitaServicosMapping : IEntityTypeConfiguration<SolicitaServicosModel>
    {
        public void Configure(EntityTypeBuilder<SolicitaServicosModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ServicosModel).WithMany(x => x.SolicitaServicosModel).HasForeignKey(x => x.TipoServico);
            builder.HasOne(x => x.UsuariosModel).WithMany(x => x.SolicitaServicosModel).HasForeignKey(x => x.Id_Usuario);
            builder.HasOne(x => x.DepartamentosModel).WithMany(x => x.SolicitaServicosModel).HasForeignKey(x => x.Id_Departamento);
            builder.HasOne(x => x.FornecedoresModel).WithMany(x => x.SolicitaServicosModel).HasForeignKey(x => x.Fornecedor);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Observacao).HasColumnName("Observation");
            builder.Property(x => x.Fornecedor).HasColumnName("Supplier");
            builder.Property(x => x.Data_Cadastro).HasColumnName("Date_Register");
            builder.Property(x => x.TipoServico).HasColumnName("Type_Service");
            builder.Property(x => x.Id_Usuario).HasColumnName("User_Id");
            builder.Property(x => x.Id_Departamento).HasColumnName("Department_Id");
            builder.Property(x => x.Ativo).HasDefaultValue(1).HasColumnName("Active");
            builder.Property(x => x.Aprovado).HasDefaultValue(0).HasColumnName("Approved");
        }
    }
}