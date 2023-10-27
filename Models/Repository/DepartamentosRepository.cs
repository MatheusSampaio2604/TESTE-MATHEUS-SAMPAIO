using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public class DepartamentosRepository : Repository<DepartamentosModel>, IDepartamentosRepository
    {
        public DepartamentosRepository(DataContext context) : base(context)
        {

        }
    }
}