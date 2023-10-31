
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Usuarios")]
    public class UsuariosModel
    {
        public int Id { get; set; }

        public required string Matricula { get; set; }

        public required string Nome { get; set; }

        public int Departamento { get; set; }

        public bool Ativo { get; set; }

        public virtual DepartamentosModel DepartamentosModel { get; set; }
        public virtual IEnumerable<SolicitaServicosModel> SolicitaServicosModel { get; set; }
        public virtual IEnumerable<SolicitaComprasModel> SolicitaComprasModel { get; set; }
    }
}