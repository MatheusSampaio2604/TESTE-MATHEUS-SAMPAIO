using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public class ProdutosRepository : Repository<ProdutosModel>, IProdutosRepository
    {
        public ProdutosRepository(DataContext context) : base(context)
        {

        }
    }
}