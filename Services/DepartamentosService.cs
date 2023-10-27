
using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    
    public class DepartamentosService : Service<DepartamentosViewModel, DepartamentosModel>, IDepartamentosService
    {
        public DepartamentosService(ILogger<DepartamentosService> logger, IMapper mapper, IDepartamentosRepository iDepartamentosRepository) : base(logger, mapper, iDepartamentosRepository)
        {
          
        }
    }
}