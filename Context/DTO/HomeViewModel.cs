namespace TESTE_MATHEUS_SAMPAIO.Context.DTO
{
    public class HomeViewModel
    {
        public IEnumerable<SolicitaServicosViewModel> Servicos { get; set; }
        public IEnumerable<SolicitaComprasViewModel> Pedidos { get; set; }
    }
}