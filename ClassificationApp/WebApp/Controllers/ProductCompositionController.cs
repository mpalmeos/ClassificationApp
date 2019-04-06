using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class ProductCompositionController : Controller
    {
        private readonly AppDbContext _context;

        public ProductCompositionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductComposition
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductCompositions.Include(p => p.Composition).Include(p => p.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductComposition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productComposition = await _context.ProductCompositions
                .Include(p => p.Composition)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productComposition == null)
            {
                return NotFound();
            }

            return View(productComposition);
        }

        // GET: ProductComposition/Create
        public IActionResult Create()
        {
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductComposition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CompositionId,Id")] ProductComposition productComposition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productComposition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", productComposition.CompositionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productComposition.ProductId);
            return View(productComposition);
        }

        // GET: ProductComposition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productComposition = await _context.ProductCompositions.FindAsync(id);
            if (productComposition == null)
            {
                return NotFound();
            }
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", productComposition.CompositionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productComposition.ProductId);
            return View(productComposition);
        }

        // POST: ProductComposition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CompositionId,Id")] ProductComposition productComposition)
        {
            if (id != productComposition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productComposition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCompositionExists(productComposition.Id))
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
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", productComposition.CompositionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productComposition.ProductId);
            return View(productComposition);
        }

        // GET: ProductComposition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productComposition = await _context.ProductCompositions
                .Include(p => p.Composition)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productComposition == null)
            {
                return NotFound();
            }

            return View(productComposition);
        }

        // POST: ProductComposition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productComposition = await _context.ProductCompositions.FindAsync(id);
            _context.ProductCompositions.Remove(productComposition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCompositionExists(int id)
        {
            return _context.ProductCompositions.Any(e => e.Id == id);
        }
    }
}
