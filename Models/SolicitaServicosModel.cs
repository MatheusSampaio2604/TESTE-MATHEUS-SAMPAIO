using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_SolicitaServicos")]
    public class SolicitaServicosModel
    {
        
        public int Id { get; set; }
        public int TipoServico{get;set;}
        public required string Observacao{get;set;}
        public int Fornecedor{get;set;} 
        public DateTime Data_Cadastro {get;set;}
        public int Id_Usuario { get; set; }
        public int Id_Departamento{get;set;}
        public bool Ativo { get; set; }


        public required virtual ServicosModel ServicosModel { get; set; }
        public required virtual UsuariosModel UsuariosModel { get; set; }
        public required virtual DepartamentosModel DepartamentosModel { get; set; }

    }
}