
namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class DepartamentosViewModel
    {
        public int Id { get; set; }

        public required string Nome { get; set; }


        public virtual IEnumerable<UsuariosViewModel>? UsuariosViewModel { get; set; }

    }
}