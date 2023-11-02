using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Services;

namespace TESTE_MATHEUS_SAMPAIO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISolicitaComprasService _solicitaComprasService;
    private readonly ISolicitaServicosService _solicitaServicoService;

    public HomeController(ILogger<HomeController> logger, ISolicitaComprasService solicitaComprasService, ISolicitaServicosService solicitaServicosService)
    {
        _logger = logger;
        _solicitaComprasService = solicitaComprasService;
        _solicitaServicoService = solicitaServicosService;
    }

    public ActionResult Index()
    {
        var viewModel = new HomeViewModel
        {
            Servicos = ObterDadosDosServicos(),
            Pedidos = ObterDadosDosPedidos() 
        };
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Solicitacoes()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IEnumerable<SolicitaServicosViewModel> ObterDadosDosServicos()
    {
        var index = _solicitaServicoService.FindAllAsync().Result;
        return index.Where(x => x.Aprovado == false);
    }

    public IEnumerable<SolicitaComprasViewModel> ObterDadosDosPedidos()
    {
        var index = _solicitaComprasService.FindAllAsync().Result;
        return index.Where(x => x.Aprovado == false);
    }
}
