using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Fornecedores")]
    public class FornecedoresModel
    {
        public int Id { get; set; }

        public string? Nome_Fornecedor { get; set; }

        public string? Email_Fornecedor { get; set; }

        public int CNPJ { get; set; }

        public int Inscricao_Estadual { get; set; }

        public int Inscricao_Municipal { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<ServicosModel>? ServicosModel { get; set; }


    }
}