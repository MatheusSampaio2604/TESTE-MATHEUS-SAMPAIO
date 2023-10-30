using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_SolicitaServicos")]
    public class SolicitaServicosModel
    {
        
        public int Id { get; set; }

        public required string Observacao{get;set;}
        public DateTime Data_Cadastro {get;set;}
        public bool Ativo { get; set; }
        public int Fornecedor{get;set;} 



        public int TipoServico{get;set;}
        public int Id_Usuario { get; set; }
        public int Id_Departamento{get;set;}



        public virtual IEnumerable<ServicosModel>? ServicosModel { get; set; }
        public virtual IEnumerable<UsuariosModel>? UsuariosModel { get; set; }
        public virtual IEnumerable<DepartamentosModel>? DepartamentosModel { get; set; }

    }
}