
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Produtos")]
    public class ProdutosModel
    {
        [Column("Id")]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public string? CodigoGTIN { get; set; }
        
        public decimal Valor {get;set;}
        
        public int Minimo_Estoque { get; set; }
        
        public int Estoque_Atual { get; set; }

    }
}