using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public class ServicosRepository : Repository<ServicosModel>, IServicosRepository
    {
        public ServicosRepository(DataContext context) : base(context)
        {

        }
    }
}