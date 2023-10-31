using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class DepartamentosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(50)]
        [DisplayName("NOME")]
        public required string Nome { get; set; }

        public bool Ativo { get; set; }

        public required virtual IEnumerable<UsuariosViewModel> UsuariosViewModel { get; set; }

        public required virtual IEnumerable<SolicitaServicosViewModel> SolicitaServicosViewModel { get; set; }
        public required virtual IEnumerable<SolicitaComprasViewModel> SolicitaComprasViewModel { get; set; }

    }
}