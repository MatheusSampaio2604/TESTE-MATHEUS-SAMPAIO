using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class SolicitaComprasViewModel
    {
        public int Id { get; set; }


        public required string Codigo_Solicitacao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(8, ErrorMessage ="Verifique o Código")]
        [MaxLength(14, ErrorMessage ="Verifique o Código")]
        [DisplayName("CODIGO GTIN")]
        public required string CodigoGTIN { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(50)]
        [DisplayName("FABRICANTE")]
        public required string Fabricante { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("QUANTIDADE")]
        public int Quantidade { get; set; }

        [DisplayName("ATIVO")]
        public bool Ativo { get; set; }
        
        [DisplayName("APROVADO")]
        public bool Aprovado {get;set;}


        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("PRODUTO")]
        public int Id_Produto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("FORNECEDOR")]
        public int Id_Fornecedor { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("USUÁRIO")]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("DEPARTAMENTO")]
        public int Id_Departamento { get; set; }



        public required virtual ProdutosViewModel ProdutosModel { get; set; }
        public required virtual FornecedoresViewModel FornecedoresModel { get; set; }
        public required virtual UsuariosViewModel UsuariosModel { get; set; }
        public required virtual DepartamentosViewModel DepartamentosModel { get; set; }

    }
}