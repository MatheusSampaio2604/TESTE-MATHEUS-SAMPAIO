using TESTE_MATHEUS_SAMPAIO.Models;

namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }

        public required string Matricula { get; set; }

        public required string Nome { get; set; }

        public int Departamento { get; set; }

        public virtual DepartamentosViewModel? DepartamentosViewModel { get; set; }

    }
}