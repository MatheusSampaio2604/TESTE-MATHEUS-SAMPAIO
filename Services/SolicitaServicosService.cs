
using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public class SolicitaServicosService : Service<SolicitaServicosViewModel, SolicitaServicosModel>, ISolicitaServicosService
    {
        public SolicitaServicosService(ILogger<SolicitaServicosService> logger, IMapper mapper, ISolicitaServicosRepository iSolicitaServicosRepository) : base(logger, mapper, iSolicitaServicosRepository)
        {

        }
    }
}