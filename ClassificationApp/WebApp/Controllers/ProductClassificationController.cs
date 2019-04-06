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
    public class ProductClassificationController : Controller
    {
        private readonly AppDbContext _context;

        public ProductClassificationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductClassification
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductClassifications.ToListAsync());
        }

        // GET: ProductClassification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productClassification = await _context.ProductClassifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productClassification == null)
            {
                return NotFound();
            }

            return View(productClassification);
        }

        // GET: ProductClassification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductClassification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductClassificationValue,Id")] ProductClassification productClassification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productClassification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productClassification);
        }

        // GET: ProductClassification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productClassification = await _context.ProductClassifications.FindAsync(id);
            if (productClassification == null)
            {
                return NotFound();
            }
            return View(productClassification);
        }

        // POST: ProductClassification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductClassificationValue,Id")] ProductClassification productClassification)
        {
            if (id != productClassification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productClassification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductClassificationExists(productClassification.Id))
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
            return View(productClassification);
        }

        // GET: ProductClassification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productClassification = await _context.ProductClassifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productClassification == null)
            {
                return NotFound();
            }

            return View(productClassification);
        }

        // POST: ProductClassification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productClassification = await _context.ProductClassifications.FindAsync(id);
            _context.ProductClassifications.Remove(productClassification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductClassificationExists(int id)
        {
            return _context.ProductClassifications.Any(e => e.Id == id);
        }
    }
}
