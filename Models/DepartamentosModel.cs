
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Departamentos")]
    public class DepartamentosModel
    {

        public int Id { get; set; }

        public required string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<UsuariosModel> UsuariosModel { get; set; }

        public virtual IEnumerable<SolicitaServicosModel> SolicitaServicosModel { get; set; }
        public virtual IEnumerable<SolicitaComprasModel> SolicitaComprasModel { get; set; }
    }
}