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
    public class ServicosController : Controller
    {
        private readonly DataContext _context;
        private readonly IServicosService _servicosService;

        public ServicosController(DataContext context, IServicosService servicosService)
        {
            _context = context;
            _servicosService = servicosService;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            return View(await _servicosService.FindAllAsync());
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0) return NotFound();

            var servicosViewModel = await _servicosService.FindOneAsync(id);

            if (servicosViewModel == null) return NotFound();

            return View(servicosViewModel);
        }

        // GET: Servicos/Create
        public IActionResult Create()
        {
            ViewData["Fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Nome_Fornecedor");
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicosViewModel servicosViewModel)
        {
            if (ModelState.IsValid)
            {
                var save = await _servicosService.CreateAsync(servicosViewModel);

                if (save == null) return View(servicosViewModel);

                else return RedirectToAction(nameof(Index));
            }
            ViewData["Fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Nome_Fornecedor", servicosViewModel.Fornecedor);
            return View(servicosViewModel);
        }

        // GET: Servicos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) return NotFound();

            var servicosViewModel = await _servicosService.FindOneAsync(id);
            if (servicosViewModel == null) return NotFound();

            ViewData["Fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Nome_Fornecedor", servicosViewModel.Fornecedor);
            return View(servicosViewModel);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServicosViewModel servicosViewModel)
        {
            if (id != servicosViewModel.Id) return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    await _servicosService.EditAsync(servicosViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicosModelExists(servicosViewModel.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fornecedor"] = new SelectList(_context.Fornecedores, "Id", "Nome_Fornecedor", servicosViewModel.Fornecedor);
            return View(servicosViewModel);
        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();


            var servicosViewModel = await _servicosService.FindOneAsync(id);
            
            if (servicosViewModel == null) return NotFound();

            return View(servicosViewModel);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicos == null)
            {
                return Problem("Entity set 'DataContext.Servicos'  is null.");
            }
            var servicosViewModel = await _context.Servicos.FindAsync(id);
            if (servicosViewModel != null)
            {
                _context.Servicos.Remove(servicosViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicosModelExists(int id)
        {
            return (_context.Servicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
