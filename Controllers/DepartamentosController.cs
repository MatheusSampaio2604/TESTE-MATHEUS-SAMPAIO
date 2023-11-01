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
            try
            {
                return View(await _departamentosService.FindAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(error: "Não foi possivel completar a sua solicitação, Tente novamente! \n" + e);
            }
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                var departamentosViewModel = await _departamentosService.FindOneAsync(id);
                if (departamentosViewModel == null)
                {
                    return NotFound();
                }

                return View(departamentosViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
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
        public async Task<IActionResult> Create(DepartamentosViewModel departamentosViewModel)
        {

            departamentosViewModel.Nome = departamentosViewModel.Nome.ToUpper();

            if (ModelState.IsValid)
            {
                return View("Edit", departamentosViewModel);
            }
            try
            {

                var create = await _departamentosService.CreateAsync(departamentosViewModel);

                if (create == null)
                    return BadRequest(error: "Não foi possivel completar a sua solicitação, Tente Novamente!");
                else
                    return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }


        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                var searchEdit = await _departamentosService.FindOneAsync(id);

                if (searchEdit == null)
                    return NotFound();

                return View(searchEdit);
            }
            catch (Exception e)
            {
                return View("Error: ", e);
            }
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartamentosViewModel departamentosViewModel)
        {
            if (id != departamentosViewModel.Id)
            {
                return NotFound();
            }

            departamentosViewModel.Nome = departamentosViewModel.Nome.ToUpper();

            if (!ModelState.IsValid)
            {
                try
                {
                    await _departamentosService.EditAsync(departamentosViewModel);
                }
                catch (Exception e)
                {
                    return View("Error: ", e);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departamentosViewModel);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            return View(await _departamentosService.FindOneAsync(id));
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DepartamentosModel departamentosModel)
        {
            try
            {
                _departamentosService.Remove(departamentosModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return BadRequest(error: "Não foi possivel completar a sua solicitação, Tente novamente!\n" + e);
            }
        }

        private bool DepartamentosModelExists(int id)
        {
            return (_context.DepartamentosModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
