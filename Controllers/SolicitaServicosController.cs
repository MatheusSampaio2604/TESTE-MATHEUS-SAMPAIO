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
    public class SolicitaServicosController : Controller
    {
        private readonly DataContext _context;
        private readonly ISolicitaServicosService _solicitaServicosService;

        public SolicitaServicosController(DataContext context, ISolicitaServicosService solicitaServicosService)
        {
            _context = context;
            _solicitaServicosService = solicitaServicosService;
        }

        // GET: SolicitaServicos
        public async Task<IActionResult> Index()
        {
            return View(await _solicitaServicosService.FindAllAsync());
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
        public IActionResult Create()
        {
            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Nome");
            ViewData["TipoServico"] = new SelectList(_context.Servicos, "Id", "Nome");
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: SolicitaServicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolicitaServicosViewModel solicitaServicosViewModel)
        {
            if (ModelState.IsValid)
            {
                var save = await _solicitaServicosService.CreateAsync(solicitaServicosViewModel);

                if (save == null) return View(solicitaServicosViewModel);

                else return RedirectToAction(nameof(Index));
            }

            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Nome", solicitaServicosViewModel.Id_Departamento);
            ViewData["TipoServico"] = new SelectList(_context.Servicos, "Id", "Nome", solicitaServicosViewModel.TipoServico);
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Nome", solicitaServicosViewModel.Id_Usuario);
            return View(solicitaServicosViewModel);
        }

        // GET: SolicitaServicos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) return NotFound();

            var solicitaServicosViewModel = await _solicitaServicosService.FindOneAsync(id);

            if (solicitaServicosViewModel == null) return NotFound();

            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Nome", solicitaServicosViewModel.Id_Departamento);
            ViewData["TipoServico"] = new SelectList(_context.Servicos, "Id", "Nome", solicitaServicosViewModel.TipoServico);
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Nome", solicitaServicosViewModel.Id_Usuario);
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
            ViewData["Id_Departamento"] = new SelectList(_context.DepartamentosModel, "Id", "Nome", solicitaServicosViewModel.Id_Departamento);
            ViewData["TipoServico"] = new SelectList(_context.Servicos, "Id", "Nome", solicitaServicosViewModel.TipoServico);
            ViewData["Id_Usuario"] = new SelectList(_context.Usuarios, "Id", "Nome", solicitaServicosViewModel.Id_Usuario);
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
    }
}
