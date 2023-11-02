using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class SolicitaServicosViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("CÓDIGO SOLICITAÇÃO")]
        public required string Codigo_Solicitacao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(200)]
        [DisplayName("OBSERVAÇÃO")]
        public required string Observacao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("DATA CADASTRO")]
        public DateTime Data_Cadastro { get; set; }

        [DisplayName("ATIVO")]
        public bool Ativo { get; set; }

        [DisplayName("APROVADO")]
        public bool Aprovado { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("FORNECEDOR")]
        public int Fornecedor { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("SERVIÇO")]
        public int TipoServico { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("USUÁRIO")]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("DEPARTAMENTO")]
        public int Id_Departamento { get; set; }



        public required virtual ServicosViewModel ServicosModel { get; set; }
        public required virtual UsuariosViewModel UsuariosModel { get; set; }
        public required virtual DepartamentosViewModel DepartamentosModel { get; set; }
        public required virtual FornecedoresViewModel FornecedoresModel { get; set; }

    }
}