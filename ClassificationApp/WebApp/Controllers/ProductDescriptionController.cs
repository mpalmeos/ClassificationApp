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
    public class ProductDescriptionController : Controller
    {
        private readonly AppDbContext _context;

        public ProductDescriptionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductDescription
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductDescriptions.Include(p => p.Description).Include(p => p.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductDescription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDescription = await _context.ProductDescriptions
                .Include(p => p.Description)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDescription == null)
            {
                return NotFound();
            }

            return View(productDescription);
        }

        // GET: ProductDescription/Create
        public IActionResult Create()
        {
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "DescriptionValue");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,DescriptionId,Id")] ProductDescription productDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "DescriptionValue", productDescription.DescriptionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDescription.ProductId);
            return View(productDescription);
        }

        // GET: ProductDescription/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDescription = await _context.ProductDescriptions.FindAsync(id);
            if (productDescription == null)
            {
                return NotFound();
            }
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "DescriptionValue", productDescription.DescriptionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDescription.ProductId);
            return View(productDescription);
        }

        // POST: ProductDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,DescriptionId,Id")] ProductDescription productDescription)
        {
            if (id != productDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDescriptionExists(productDescription.Id))
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
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "DescriptionValue", productDescription.DescriptionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDescription.ProductId);
            return View(productDescription);
        }

        // GET: ProductDescription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDescription = await _context.ProductDescriptions
                .Include(p => p.Description)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDescription == null)
            {
                return NotFound();
            }

            return View(productDescription);
        }

        // POST: ProductDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDescription = await _context.ProductDescriptions.FindAsync(id);
            _context.ProductDescriptions.Remove(productDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDescriptionExists(int id)
        {
            return _context.ProductDescriptions.Any(e => e.Id == id);
        }
    }
}
