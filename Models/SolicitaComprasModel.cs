using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TESTE_MATHEUS_SAMPAIO.Models
{
    [Table("TBL_SolicitaPedidos")]
    public class SolicitaComprasModel
    {
        public int Id { get; set; }
        public required string Codigo_Solicitacao { get; set; }
        public int Id_Produto { get; set; }
        public required string CodigoGTIN { get; set; }
        public required string Fabricante { get; set; }
        public int Quantidade { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Departamento { get; set; }
        public int Id_Fornecedor { get; set; }
        public bool Ativo { get; set; }
        public bool Aprovado {get;set;}

        public required virtual ProdutosModel ProdutosModel {get;set;}
        public required virtual FornecedoresModel FornecedoresModel { get; set; }
        public required virtual UsuariosModel UsuariosModel { get; set; }
        public required virtual DepartamentosModel DepartamentosModel { get; set; }

    }
}