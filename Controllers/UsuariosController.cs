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
            usuariosViewModel.Matricula = await CriaMatricula();


            if (ModelState.IsValid) return View(usuariosViewModel);

            try
            {
                var success = await _usuariosService.CreateAsync(usuariosViewModel);

                if (success == null)
                    return BadRequest(error: "Não foi possivel processar sua Solicitação, tente novamente!");
                else
                    return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error: ", e);
            }
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0) return NotFound();

            try
            {
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

            if (ModelState.IsValid) return View("Edit", usuariosViewModel);

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

        private async Task<string> CriaMatricula()
        {
            char proximaLetra = 'A';
            int proximoNumero = 0;

            var i = await _usuariosService.FindAllAsync();

            if (i.Any())
            {
                int matriculaInt = 0;

                var maiorMatricula = i
                    .Where(u => !string.IsNullOrEmpty(u.Matricula) && u.Matricula.Length >= 5 && char.IsLetter(u.Matricula[0]) &&
                                int.TryParse(u.Matricula.Substring(1), out matriculaInt))
                    .Max(u => matriculaInt);

                if (maiorMatricula >= 0)
                {
                    proximaLetra = (char)('A' + (maiorMatricula / 10000));
                    proximoNumero = (maiorMatricula % 10000) + 1;
                }

                if (proximoNumero > 9999)
                {
                    proximoNumero = 0;

                    if (proximaLetra < 'Z')
                    {
                        proximaLetra++;
                    }
                    else
                    {
                        proximaLetra = 'A';
                        proximoNumero = 0;
                    }
                }
            }

            return $"{proximaLetra}{proximoNumero:D4}";
        }
    }
}
