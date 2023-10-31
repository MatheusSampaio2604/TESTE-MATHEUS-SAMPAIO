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
    public class FornecedoresController : Controller
    {
        private readonly DataContext _context;
        private readonly IFornecedoresService _fornecedoresService;

        public FornecedoresController(DataContext context, IFornecedoresService fornecedoresService)
        {
            _context = context;
            _fornecedoresService = fornecedoresService;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
            return View(await _fornecedoresService.FindAllAsync());
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0 || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedoresViewModel = await _fornecedoresService.FindOneAsync(id);
            if (fornecedoresViewModel == null)
                return NotFound();

            return View(fornecedoresViewModel);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedoresViewModel fornecedoresViewModel)
        {
            if (!ModelState.IsValid)
            {
                var created = await _fornecedoresService.CreateAsync(fornecedoresViewModel);
                if (created != null)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest(error: "Não foi possivel completar a sua solicitação, Tente Novamente!");
            }
            return View(fornecedoresViewModel);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedoresViewModel = await _fornecedoresService.FindOneAsync(id);
            if (fornecedoresViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedoresViewModel);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FornecedoresViewModel fornecedoresViewModel)
        {
            if (id != fornecedoresViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var edited = await _fornecedoresService.EditAsync(fornecedoresViewModel);
                    if (edited != null)
                        return RedirectToAction(nameof(Index));
                    else
                        return View(fornecedoresViewModel);
                }
                catch (Exception e)
                {
                    return BadRequest(error: "Não foi possivel completar a sua solicitação, Tente Novamente!\n" + e);
                }

            }
            return View(fornecedoresViewModel);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedoresViewModel = await _fornecedoresService.FindOneAsync(id);

            if (fornecedoresViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedoresViewModel);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, FornecedoresModel fornecedoresModel)
        {
            try
            {
                _fornecedoresService.Remove(fornecedoresModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        private bool FornecedoresModelExists(int id)
        {
            return (_context.Fornecedores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
