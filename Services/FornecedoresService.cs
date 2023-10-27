
using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public class FornecedoresService : Service<FornecedoresViewModel, FornecedoresModel>, IFornecedoresService
    {
        public FornecedoresService(ILogger<FornecedoresService> logger, IMapper mapper, IFornecedoresRepository iFornecedoresRepository) : base(logger, mapper, iFornecedoresRepository)
        {

        }
    }
}