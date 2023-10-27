using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public class UsuariosRepository : Repository<UsuariosModel>, IUsuariosRepository
    {
        public UsuariosRepository(DataContext context) : base(context)
        {

        }
    }
}