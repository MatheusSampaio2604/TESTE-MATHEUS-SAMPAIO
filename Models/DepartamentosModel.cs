
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Departamentos")]
    public class DepartamentosModel
    {

        public int Id { get; set; }

        public required string Nome { get; set; }

        public bool Ativo { get; set; }

        public required virtual IEnumerable<UsuariosModel> UsuariosModel { get; set; }
        public required virtual IEnumerable<SolicitaServicosModel> SolicitaServicosModel { get; set; }
        public required virtual IEnumerable<SolicitaComprasModel> SolicitaComprasModel { get; set; }
    }
}