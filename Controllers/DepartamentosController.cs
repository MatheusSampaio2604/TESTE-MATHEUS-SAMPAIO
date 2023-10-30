using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Services;

namespace TESTE_MATHEUS_SAMPAIO.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly DataContext _context;
        private readonly IDepartamentosService _departamentosService;

        public DepartamentosController(DataContext context, IDepartamentosService departamentosService)
        {
            _context = context;
            _departamentosService = departamentosService;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
              return View(await _departamentosService.FindAllAsync());
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartamentosModel == null)
            {
                return NotFound();
            }

            var departamentosModel = await _context.DepartamentosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentosModel == null)
            {
                return NotFound();
            }

            return View(departamentosModel);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] DepartamentosModel departamentosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentosModel);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartamentosModel == null)
            {
                return NotFound();
            }

            var departamentosModel = await _context.DepartamentosModel.FindAsync(id);
            if (departamentosModel == null)
            {
                return NotFound();
            }
            return View(departamentosModel);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] DepartamentosModel departamentosModel)
        {
            if (id != departamentosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentosModelExists(departamentosModel.Id))
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
            return View(departamentosModel);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartamentosModel == null)
            {
                return NotFound();
            }

            var departamentosModel = await _context.DepartamentosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentosModel == null)
            {
                return NotFound();
            }

            return View(departamentosModel);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartamentosModel == null)
            {
                return Problem("Entity set 'DataContext.DepartamentosModel'  is null.");
            }
            var departamentosModel = await _context.DepartamentosModel.FindAsync(id);
            if (departamentosModel != null)
            {
                _context.DepartamentosModel.Remove(departamentosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentosModelExists(int id)
        {
          return (_context.DepartamentosModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
