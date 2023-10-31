using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public class SolicitaComprasRepository : Repository<SolicitaComprasModel>, ISolicitaComprasRepository
    {
        public SolicitaComprasRepository(DataContext context) : base(context)
        {

        }
    }
}