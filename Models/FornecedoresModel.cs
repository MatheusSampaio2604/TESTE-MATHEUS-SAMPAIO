using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_Fornecedores")]
    public class FornecedoresModel
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string  CNPJ { get; set; }

        public required string Inscricao_Estadual { get; set; }

        public required string Inscricao_Municipal { get; set; }

        public bool Ativo { get; set; }

        public required virtual IEnumerable<ServicosModel> ServicosModel { get; set; }
        public required virtual IEnumerable<SolicitaComprasModel> SolicitaComprasModel {get;set;}
        public required virtual IEnumerable<SolicitaServicosModel> SolicitaServicosModel { get; set; }

    }
}