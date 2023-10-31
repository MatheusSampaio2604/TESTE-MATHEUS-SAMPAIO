
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(6)]
        [DisplayName("MATRÍCULA")]
        public required string Matricula { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(75)]
        [DisplayName("NOME")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("DEPARTAMENTO")]
        public int Departamento { get; set; }



        public bool Ativo { get; set; }

        public required virtual DepartamentosViewModel DepartamentosViewModel { get; set; }
        public required virtual IEnumerable<SolicitaServicosViewModel> SolicitaServicosViewModel { get; set; }
        public required virtual IEnumerable<SolicitaComprasViewModel> SolicitaComprasViewModel { get; set; }

    }
}