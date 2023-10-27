namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class ServicosViewModel
    {
        
        public int Id { get; set; }

        
        public string? Nome_Servico { get; set; }

       
        public string? Descricao_Servico { get; set; }
        
        
        public decimal Prazo_Entrega {get;set;}
        
       
        public int Fornecedor { get; set; }
        
        
        public virtual FornecedoresViewModel? Fornecedores { get; set; }

    }
}