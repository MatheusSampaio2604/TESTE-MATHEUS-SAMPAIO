using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public class FornecedoresRepository : Repository<FornecedoresModel>, IFornecedoresRepository
    {
        public FornecedoresRepository(DataContext context) : base(context)
        {

        }
    }
}