using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public class SolicitaServicosRepository : Repository<SolicitaServicosModel>, ISolicitaServicosRepository
    {
        public SolicitaServicosRepository(DataContext context) : base(context)
        {

        }
    }
}