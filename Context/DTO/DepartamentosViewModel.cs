
namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class DepartamentosViewModel
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<UsuariosViewModel> UsuariosViewModel { get; set; }

    }
}