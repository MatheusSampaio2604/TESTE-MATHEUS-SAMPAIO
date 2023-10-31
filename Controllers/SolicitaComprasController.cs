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

        public SolicitaComprasController(DataContext context, ISolicitaComprasService solicitaComprasService)
        {
            _context = context;
            _solicitaComprasService = solicitaComprasService;
        }

        // GET: SolicitaCompras
        public async Task<IActionResult> Index()
        {
            return View(await _solicitaComprasService.FindAllAsync());
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
        public IActionResult Create()
        {
            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Nome");
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Nome_Fornecedor");
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Nome");
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: SolicitaCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolicitaComprasViewModel solicitaComprasViewModel)
        {
            if (ModelState.IsValid)
            {
                var save = await _solicitaComprasService.CreateAsync(solicitaComprasViewModel);

                if (save == null) return View(solicitaComprasViewModel);
                else return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Id", solicitaComprasViewModel.Id_Departamento);
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Id", solicitaComprasViewModel.Id_Fornecedor);
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Id", solicitaComprasViewModel.Id_Produto);
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Id", solicitaComprasViewModel.Id_Usuario);
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

            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Nome", solicitaComprasViewModel.Id_Departamento);
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Nome_Fornecedor", solicitaComprasViewModel.Id_Fornecedor);
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Nome", solicitaComprasViewModel.Id_Produto);
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Nome", solicitaComprasViewModel.Id_Usuario);
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

            if (ModelState.IsValid)
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
            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Nome", solicitaComprasViewModel.Id_Departamento);
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedores, "Nome_Fornecedor", "Id", solicitaComprasViewModel.Id_Fornecedor);
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Nome", solicitaComprasViewModel.Id_Produto);
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Nome", solicitaComprasViewModel.Id_Usuario);
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
    }
}
