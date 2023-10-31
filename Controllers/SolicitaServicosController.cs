using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Services;

namespace TESTE_MATHEUS_SAMPAIO.Controllers
{
    public class SolicitaServicosController : Controller
    {
        private readonly DataContext _context;
        private readonly ISolicitaServicosService _solicitaServicosService;
        private readonly IDepartamentosService _departamentosService;
        private readonly IServicosService _servicosService;
        private readonly IUsuariosService _usuariosService;
        private readonly IFornecedoresService _fornecedoresService;

        public SolicitaServicosController(DataContext context, ISolicitaServicosService solicitaServicosService, IDepartamentosService departamentosService, IServicosService servicosService, IUsuariosService usuariosService, IFornecedoresService fornecedoresService)
        {
            _context = context;
            _solicitaServicosService = solicitaServicosService;
            _departamentosService = departamentosService;
            _servicosService = servicosService;
            _usuariosService = usuariosService;
            _fornecedoresService = fornecedoresService;
        }

        // GET: SolicitaServicos
        public async Task<IActionResult> Index()
        {
            var index = await _solicitaServicosService.FindAllAsync();
            return View(index.Where(x => x.Aprovado == false));
        }

        // GET: SolicitaServicos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();

            var solicitaServicosViewModel = await _solicitaServicosService.FindOneAsync(id);

            if (solicitaServicosViewModel == null) return NotFound();

            return View(solicitaServicosViewModel);
        }

        // GET: SolicitaServicos/Create
        public async Task<IActionResult> Create()
        {
            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var servico = await _servicosService.FindAllAsync(); ViewBag.Servico = servico;

            return View();
        }

        // POST: SolicitaServicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolicitaServicosViewModel solicitaServicosViewModel)
        {
            if (!ModelState.IsValid)
            {
                var save = await _solicitaServicosService.CreateAsync(solicitaServicosViewModel);

                if (save == null) return View(solicitaServicosViewModel);

                else return RedirectToAction(nameof(Index));
            }

            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var servico = await _servicosService.FindAllAsync(); ViewBag.Servico = servico;
            return View(solicitaServicosViewModel);
        }

        // GET: SolicitaServicos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) return NotFound();

            var solicitaServicosViewModel = await _solicitaServicosService.FindOneAsync(id);

            if (solicitaServicosViewModel == null) return NotFound();


            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var servico = await _servicosService.FindAllAsync(); ViewBag.Servico = servico;
            return View(solicitaServicosViewModel);
        }

        // POST: SolicitaServicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SolicitaServicosViewModel solicitaServicosViewModel)
        {
            if (id != solicitaServicosViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _solicitaServicosService.EditAsync(solicitaServicosViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitaServicosModelExists(solicitaServicosViewModel.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var servico = await _servicosService.FindAllAsync(); ViewBag.Servico = servico;
            return View(solicitaServicosViewModel);
        }

        // GET: SolicitaServicos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();

            var solicitaServicosViewModel = await _solicitaServicosService.FindOneAsync(id);

            if (solicitaServicosViewModel == null) return NotFound();

            return View(solicitaServicosViewModel);
        }

        // POST: SolicitaServicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, SolicitaServicosModel solicitaServicosViewModel)
        {
            try
            {
                _solicitaServicosService.Remove(solicitaServicosViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


        private bool SolicitaServicosModelExists(int id)
        {
            return (_context.SolicitaServicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> IndexServicoAprovados()
        {
            var aprovados = await _solicitaServicosService.FindAllAsync();
            return View(aprovados.Where(x => x.Aprovado == true));
        }
    }
}
