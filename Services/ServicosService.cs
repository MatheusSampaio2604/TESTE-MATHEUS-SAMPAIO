
using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public class ServicosService : Service<ServicosViewModel, ServicosModel>, IServicosService
    {
        public ServicosService(ILogger<ServicosService> logger, IMapper mapper, IServicosRepository iServicosRepository) : base(logger, mapper, iServicosRepository)
        {

        }
    }
}