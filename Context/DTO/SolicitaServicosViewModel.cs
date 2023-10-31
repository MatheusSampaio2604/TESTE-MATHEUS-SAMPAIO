using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class SolicitaServicosViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(200)]
        [DisplayName("OBSERVAÇÃO")]
        public required string Observacao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("DATA CADASTRO")]
        public DateTime Data_Cadastro { get; set; }

        public bool Ativo { get; set; }

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
        [DisplayName("DEPARTAMENTO USUARIO")]
        public int Id_Departamento { get; set; }



        public virtual ServicosViewModel ServicosViewModel { get; set; }
        public virtual UsuariosViewModel UsuariosViewModel { get; set; }
        public virtual DepartamentosViewModel DepartamentosViewModel { get; set; }

    }
}