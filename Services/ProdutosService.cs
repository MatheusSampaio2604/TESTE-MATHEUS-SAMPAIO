
using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public class ProdutosService : Service<ProdutosViewModel, ProdutosModel>, IProdutosService
    {
        public ProdutosService(ILogger<ProdutosService> logger, IMapper mapper, IProdutosRepository iProdutosRepository) : base(logger, mapper, iProdutosRepository)
        {

        }
    }
}