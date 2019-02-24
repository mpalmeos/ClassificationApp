using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class ProductDosageController : Controller
    {
        private readonly AppDbContext _context;

        public ProductDosageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductDosage
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductDosages.Include(p => p.Dosage).Include(p => p.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductDosage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDosage = await _context.ProductDosages
                .Include(p => p.Dosage)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDosage == null)
            {
                return NotFound();
            }

            return View(productDosage);
        }

        // GET: ProductDosage/Create
        public IActionResult Create()
        {
            ViewData["DosageId"] = new SelectList(_context.Dosages, "Id", "DosageValue");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductDosage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosageId,ProductId,Id")] ProductDosage productDosage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDosage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DosageId"] = new SelectList(_context.Dosages, "Id", "DosageValue", productDosage.DosageId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDosage.ProductId);
            return View(productDosage);
        }

        // GET: ProductDosage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDosage = await _context.ProductDosages.FindAsync(id);
            if (productDosage == null)
            {
                return NotFound();
            }
            ViewData["DosageId"] = new SelectList(_context.Dosages, "Id", "DosageValue", productDosage.DosageId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDosage.ProductId);
            return View(productDosage);
        }

        // POST: ProductDosage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosageId,ProductId,Id")] ProductDosage productDosage)
        {
            if (id != productDosage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDosage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDosageExists(productDosage.Id))
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
            ViewData["DosageId"] = new SelectList(_context.Dosages, "Id", "DosageValue", productDosage.DosageId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDosage.ProductId);
            return View(productDosage);
        }

        // GET: ProductDosage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDosage = await _context.ProductDosages
                .Include(p => p.Dosage)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDosage == null)
            {
                return NotFound();
            }

            return View(productDosage);
        }

        // POST: ProductDosage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDosage = await _context.ProductDosages.FindAsync(id);
            _context.ProductDosages.Remove(productDosage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDosageExists(int id)
        {
            return _context.ProductDosages.Any(e => e.Id == id);
        }
    }
}
