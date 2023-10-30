using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
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
            try
            {
                return View(await _usuariosService.FindAllAsync());
            }
            catch (Exception e)
            {
                return View("Error\n", e);
            }
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == 0 || _context.Usuarios == null)
                {
                    return NotFound();
                }

                var usuariosViewModel = await _usuariosService.FindOneAsync(id);

                if (usuariosViewModel == null)
                {
                    return NotFound();
                }

                return View(usuariosViewModel);
            }
            catch (Exception e)
            {
                return View("Error: ", e);
            }
        }

        // GET: Usuarios/Create
        public async Task<IActionResult> Create()
        {
            var depart = await _departamentosService.FindAllAsync();
            ViewBag.Departamentos = depart.Where(x => x.Ativo == true);

            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuariosViewModel usuariosViewModel)
        {

            usuariosViewModel.Nome = usuariosViewModel.Nome.ToUpper();

            try
            {
                if (ModelState.IsValid)
                {
                    var success = await _usuariosService.CreateAsync(usuariosViewModel);
                    if (success != null)
                        return RedirectToAction(nameof(Index));
                    else
                        return BadRequest(error: "Não foi possivel processar sua Solicitação, tente novamente!");
                }

                return View(usuariosViewModel);
            }
            catch (Exception e)
            {
                return View("Error: ", e);
            }
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == 0 || _context.Usuarios == null)
                {
                    return NotFound();
                }
                var depart = await _departamentosService.FindAllAsync();
                ViewBag.Departamentos = depart.Where(x => x.Ativo == true);
                
                return View(await _usuariosService.FindOneAsync(id));
            }
            catch (Exception e)
            {
                return View("Error: ", e);
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuariosViewModel usuariosViewModel)
        {
            if (id != usuariosViewModel.Id)
            {
                return NotFound();
            }

            usuariosViewModel.Nome = usuariosViewModel.Nome.ToUpper();

            if (ModelState.IsValid)
            {
                try
                {
                    await _usuariosService.EditAsync(usuariosViewModel);
                }
                catch (Exception e)
                {
                    if (!UsuariosModelExists(usuariosViewModel.Id))
                    {
                        return NotFound(e);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(usuariosViewModel);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _context.Usuarios == null)
            {
                return NotFound();
            }

            var delete = await _usuariosService.FindOneAsync(id);
            if (delete == null)
            {
                return NotFound();
            }

            return View(delete);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(UsuariosModel usuariosModel)
        {
            try
            {
                _usuariosService.Remove(usuariosModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return BadRequest(error: "Não foi possivel completar a sua solicitação, Tente novamente!\n" + e);
            }

        }

        private bool UsuariosModelExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
