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
    public class UsuariosController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsuariosService _usuariosService;
        private readonly IDepartamentosService _departamentosService;

        public UsuariosController(DataContext context, IUsuariosService usuariosService, IDepartamentosService departamentosService)
        {
            _context = context;
            _usuariosService = usuariosService;
            _departamentosService = departamentosService;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var depart = await _departamentosService.FindAllAsync() ?? null;
            ViewBag.Departamentos = depart;
            return View(await _usuariosService.FindAllAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuariosModel = await _context.Usuarios
                .Include(u => u.DepartamentosModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuariosModel == null)
            {
                return NotFound();
            }

            return View(usuariosModel);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["Departamento"] = new SelectList(_context.Set<DepartamentosModel>(), "Id", "Id");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricula,Nome,Departamento")] UsuariosModel usuariosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuariosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Departamento"] = new SelectList(_context.Set<DepartamentosModel>(), "Id", "Id", usuariosModel.Departamento);
            return View(usuariosModel);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuariosModel = await _context.Usuarios.FindAsync(id);
            if (usuariosModel == null)
            {
                return NotFound();
            }
            ViewData["Departamento"] = new SelectList(_context.Set<DepartamentosModel>(), "Id", "Id", usuariosModel.Departamento);
            return View(usuariosModel);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,Nome,Departamento")] UsuariosModel usuariosModel)
        {
            if (id != usuariosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuariosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosModelExists(usuariosModel.Id))
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
            ViewData["Departamento"] = new SelectList(_context.Set<DepartamentosModel>(), "Id", "Id", usuariosModel.Departamento);
            return View(usuariosModel);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuariosModel = await _context.Usuarios
                .Include(u => u.DepartamentosModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuariosModel == null)
            {
                return NotFound();
            }

            return View(usuariosModel);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'DataContext.Usuarios'  is null.");
            }
            var usuariosModel = await _context.Usuarios.FindAsync(id);
            if (usuariosModel != null)
            {
                _context.Usuarios.Remove(usuariosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosModelExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
