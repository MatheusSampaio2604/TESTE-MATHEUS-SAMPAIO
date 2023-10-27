using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class FornecedoresViewModel
    {

        public int Id { get; set; }

        public string? Nome_Fornecedor { get; set; }

        public string? Email_Fornecedor { get; set; }

        public int CNPJ { get; set; }

        public int Inscricao_Estadual { get; set; }

        public int Inscricao_Municipal { get; set; }

        public virtual ICollection<ServicosViewModel>? Servicos { get; set; }
        
    }
}