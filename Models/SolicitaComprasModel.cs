using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_SolicitaPedidos")]
    public class SolicitaComprasModel
    {
        public int Id { get; set; }
        public required string Codigo_Solicitacao { get; set; }
        public int CodigoGTIN { get; set; }
        public required string Fabricante { get; set; }
        public int Quantidade { get; set; }



        public int Id_Produto { get; set; }
        public int Id_Departamento { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Fornecedor { get; set; }
        public bool Ativo { get; set; }


        public virtual IEnumerable<ProdutosModel>? ProdutosModel {get;set;}
        public virtual IEnumerable<FornecedoresModel>? FornecedoresModel { get; set; }
        public virtual IEnumerable<UsuariosModel>? UsuariosModel { get; set; }
        public virtual IEnumerable<DepartamentosModel>? DepartamentosModel { get; set; }

    }
}