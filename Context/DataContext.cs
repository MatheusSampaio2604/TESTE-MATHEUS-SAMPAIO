using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;
using TESTE_MATHEUS_SAMPAIO.Context.DTO.AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<ServicosModel> Servicos { get; set; }
        public DbSet<UsuariosModel> Usuarios { get; set; }
        public DbSet<FornecedoresModel> Fornecedores { get; set; }
        public DbSet<SolicitaComprasModel> SolicitaCompras { get; set; }
        public DbSet<SolicitaServicosModel> SolicitaServicos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(k => k.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly, x => x.Namespace == "TESTE_MATHEUS_SAMPAIO.Context.DTO.Mapping");
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Outros serviços e configurações aqui

            services.AddAutoMapperConfiguration();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableDetailedErrors();
        }

        public DbSet<TESTE_MATHEUS_SAMPAIO.Models.DepartamentosModel> DepartamentosModel { get; set; } = default!;
    }

}