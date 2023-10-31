using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class ServicosViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(75)]
        [DisplayName("NOME")]
        public required string Nome_Servico { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(500)]
        [DisplayName("DESCRIÇÃO")]
        public required string Descricao_Servico { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("PRAZO MÉDIO DE ENTREGA")]
        public int Prazo_Entrega { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("FORNECEDOR")]
        public int Fornecedor { get; set; }


        public virtual FornecedoresViewModel Fornecedores { get; set; }

        public virtual IEnumerable<SolicitaServicosViewModel> SolicitaServicosViewModel { get; set; }

    }
}