using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class ProdutosViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo_GTIN { get; set; }
        public decimal Valor {get;set;}
        public int Minimo_Estoque { get; set; }
        public int Estoque_Atual { get; set; }

    }
}
