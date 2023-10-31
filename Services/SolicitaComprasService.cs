
using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public class SolicitaComprasService : Service<SolicitaComprasViewModel, SolicitaComprasModel>, ISolicitaComprasService
    {
        public SolicitaComprasService(ILogger<SolicitaComprasService> logger, IMapper mapper, ISolicitaComprasRepository iSolicitaComprasRepository) : base(logger, mapper, iSolicitaComprasRepository)
        {

        }
    }
}