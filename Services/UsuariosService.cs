
using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public class UsuariosService : Service<UsuariosViewModel, UsuariosModel>, IUsuariosService
    {
        public UsuariosService(ILogger<UsuariosService> logger, IMapper mapper, IUsuariosRepository iUsuariosRepository) : base(logger, mapper, iUsuariosRepository)
        {

        }
    }
}