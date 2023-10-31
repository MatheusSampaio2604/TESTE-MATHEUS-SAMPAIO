using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class ProdutosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(75)]
        [DisplayName("NOME")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(8)]
        [MaxLength(14)]
        [DisplayName("CODIGO GTIN")]
        public long CodigoGTIN { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("VALOR")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("ESTOQUE MÍNIMO")]
        public int Minimo_Estoque { get; set; }


        [Required(ErrorMessage = "Estoque Atual é obrigatório.")]
        [DisplayName("ESTOQUE ATUAL")]
        [Range(0, int.MaxValue, ErrorMessage = "Estoque Atual não pode ser menor que o valor mínimo.")]
        public int Estoque_Atual { get; set; }


        public virtual IEnumerable<SolicitaComprasViewModel> SolicitaComprasViewModel { get; set; }


    }
}
