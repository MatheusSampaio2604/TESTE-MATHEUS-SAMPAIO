using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Services;

namespace TESTE_MATHEUS_SAMPAIO.Controllers
{
    public class SolicitaComprasController : Controller
    {
        private readonly DataContext _context;
        private readonly ISolicitaComprasService _solicitaComprasService;
        private readonly IDepartamentosService _departamentosService;
        private readonly IFornecedoresService _fornecedoresService;
        private readonly IUsuariosService _usuariosService;
        private readonly IProdutosService _produtosService;


        public SolicitaComprasController(DataContext context, ISolicitaComprasService solicitaComprasService, IDepartamentosService departamentosService, IFornecedoresService fornecedoresService, IProdutosService produtosService, IUsuariosService usuariosService)
        {
            _context = context;
            _solicitaComprasService = solicitaComprasService;
            _departamentosService = departamentosService;
            _fornecedoresService = fornecedoresService;
            _produtosService = produtosService;
            _usuariosService = usuariosService;
        }

        // GET: SolicitaCompras
        public async Task<IActionResult> Index()
        {
            var index = await _solicitaComprasService.FindAllAsync();
            return View(index.Where(x => x.Aprovado == false));
        }

        // GET: SolicitaCompras/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();

            var solicitaComprasViewModel = await _solicitaComprasService.FindOneAsync(id);

            if (solicitaComprasViewModel == null) return NotFound();

            return View(solicitaComprasViewModel);
        }

        // GET: SolicitaCompras/Create
        public async Task<IActionResult> Create()
        {
            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var produto = await _produtosService.FindAllAsync(); ViewBag.Produto = produto;

            return View();
        }

        // POST: SolicitaCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolicitaComprasViewModel solicitaComprasViewModel)
        {
            if (!ModelState.IsValid)
            {
                var save = await _solicitaComprasService.CreateAsync(solicitaComprasViewModel);

                if (save == null) return View(solicitaComprasViewModel);
                else return RedirectToAction(nameof(Index));
            }


            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var produto = await _produtosService.FindAllAsync(); ViewBag.Produto = produto;
            return View(solicitaComprasViewModel);
        }

        // GET: SolicitaCompras/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var solicitaComprasViewModel = await _solicitaComprasService.FindOneAsync(id);

            if (solicitaComprasViewModel == null) return NotFound();

            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var produto = await _produtosService.FindAllAsync(); ViewBag.Produto = produto;
            return View(solicitaComprasViewModel);
        }

        // POST: SolicitaCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SolicitaComprasViewModel solicitaComprasViewModel)
        {
            if (id != solicitaComprasViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    await _solicitaComprasService.EditAsync(solicitaComprasViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitaComprasModelExists(solicitaComprasViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var departamento = await _departamentosService.FindAllAsync(); ViewBag.Departamento = departamento.Where(x => x.Ativo == true);
            var fornecedor = await _fornecedoresService.FindAllAsync(); ViewBag.Fornecedor = fornecedor.Where(x => x.Ativo == true);
            var usuario = await _usuariosService.FindAllAsync(); ViewBag.Usuario = usuario.Where(x => x.Ativo == true);
            var produto = await _produtosService.FindAllAsync(); ViewBag.Produto = produto;
            return View(solicitaComprasViewModel);
        }

        // GET: SolicitaCompras/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();

            var solicitaComprasViewModel = await _solicitaComprasService.FindOneAsync(id);

            if (solicitaComprasViewModel == null) return NotFound();

            return View(solicitaComprasViewModel);
        }

        // POST: SolicitaCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, SolicitaComprasModel solicitaComprasModel)
        {
            try
            {
                _solicitaComprasService.Remove(solicitaComprasModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        private bool SolicitaComprasModelExists(int id)
        {
            return (_context.SolicitaCompras?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> IndexCompraAprovados()
        {
            var aprovados = await _solicitaComprasService.FindAllAsync();
            return View(aprovados.Where(x => x.Aprovado == true));
        }
    }
}
