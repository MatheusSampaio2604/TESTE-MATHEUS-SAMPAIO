using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;
using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Context.DTO;
using TESTE_MATHEUS_SAMPAIO.Models;
using TESTE_MATHEUS_SAMPAIO.Services;

namespace TESTE_MATHEUS_SAMPAIO.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly DataContext _context;
        private readonly IProdutosService _produtosService;
        private readonly IFornecedoresService _fornecedoresService;

        public ProdutosController(DataContext context, IProdutosService produtosService, IFornecedoresService fornecedoresService)
        {
            _context = context;
            _produtosService = produtosService;
            _fornecedoresService = fornecedoresService;
        }

        // GET: Produtos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<ProdutosViewModel> item = await _produtosService.FindAllAsync();

                return View(item);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: Produtos/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == 0 || _context.Produtos == null)
                    return NotFound();


                var produtosViewModel = await _produtosService.FindOneAsync(id);

                if (produtosViewModel == null)
                    return NotFound();

                return View(produtosViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: Produtos/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var fornecedores = await _fornecedoresService.FindAllAsync();
            ViewBag.Fornecedores = fornecedores.Where(x => x.Ativo == true);

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutosViewModel produtosViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(produtosViewModel);
            }

            produtosViewModel.Nome = produtosViewModel.Nome.ToUpper();

            try
            {

                var create = await _produtosService.CreateAsync(produtosViewModel);

                if (create is null)
                    return View("Create", produtosViewModel);
                else
                    return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: Produtos/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == 0 || _context.Produtos == null)
                    return NotFound();

                var fornecedores = await _fornecedoresService.FindAllAsync();
                ViewBag.Fornecedores = fornecedores.Where(x => x.Ativo == true);

                var produtosViewModel = await _produtosService.FindOneAsync(id);

                if (produtosViewModel == null)
                    return NotFound();
                    
                return View(produtosViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProdutosViewModel produtosViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(produtosViewModel);
            }

            produtosViewModel.Nome.ToUpper();

            try
            {
                produtosViewModel.Nome = produtosViewModel.Nome.ToUpper();

                var edit = await _produtosService.EditAsync(produtosViewModel);

                if (edit is null)
                    return View("Error");

                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: Produtos/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _produtosService.FindOneAsync(id));
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProdutosModel produtosModel)
        {
            try
            {
                _produtosService.Remove(produtosModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        private bool ProdutosModelExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
