using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class FornecedoresViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("NOME")]
        [MaxLength(75)]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(5)]
        [DisplayName("EMAIL")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(14)]
        [DisplayName("CNPJ")]
        public required string CNPJ { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(10)]
        [DisplayName("INSCRIÇÃO ESTADUAL")]
        public required string Inscricao_Estadual { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(6)]
        [MaxLength(12)]
        [DisplayName("INSCRIÇÃO MUNICIPAL")]
        public required string Inscricao_Municipal { get; set; }

        public bool Ativo { get; set; }

        public required virtual IEnumerable<ServicosViewModel> Servicos { get; set; }
        public required virtual IEnumerable<SolicitaComprasViewModel> SolicitaComprasViewModel { get; set; }

    }
}