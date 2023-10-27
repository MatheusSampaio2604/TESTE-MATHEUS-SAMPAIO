
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Departamentos")]
    public class DepartamentosModel
    {

        public int Id { get; set; }

        public required string Nome { get; set; }

        public virtual ICollection<UsuariosModel>? UsuariosModel { get; set; }

    }
}