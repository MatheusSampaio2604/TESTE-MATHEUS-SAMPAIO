using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Servicos")]
    public class ServicosModel
    {
        public int Id { get; set; }

        public string? Nome_Servico { get; set; }

        public string? Descricao_Servico { get; set; }
        
        public decimal Prazo_Entrega {get;set;}
        
        public int Fornecedor { get; set; }
        
        
        public virtual FornecedoresModel? FornecedoresModel { get; set; }

    }
}