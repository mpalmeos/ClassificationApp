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
    public class ProductCompanyController : Controller
    {
        private readonly AppDbContext _context;

        public ProductCompanyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductCompany
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductCompanies.Include(p => p.Company).Include(p => p.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductCompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCompany = await _context.ProductCompanies
                .Include(p => p.Company)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCompany == null)
            {
                return NotFound();
            }

            return View(productCompany);
        }

        // GET: ProductCompany/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CompanyId,Id")] ProductCompany productCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", productCompany.CompanyId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productCompany.ProductId);
            return View(productCompany);
        }

        // GET: ProductCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCompany = await _context.ProductCompanies.FindAsync(id);
            if (productCompany == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", productCompany.CompanyId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productCompany.ProductId);
            return View(productCompany);
        }

        // POST: ProductCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CompanyId,Id")] ProductCompany productCompany)
        {
            if (id != productCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCompanyExists(productCompany.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", productCompany.CompanyId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productCompany.ProductId);
            return View(productCompany);
        }

        // GET: ProductCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCompany = await _context.ProductCompanies
                .Include(p => p.Company)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCompany == null)
            {
                return NotFound();
            }

            return View(productCompany);
        }

        // POST: ProductCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCompany = await _context.ProductCompanies.FindAsync(id);
            _context.ProductCompanies.Remove(productCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCompanyExists(int id)
        {
            return _context.ProductCompanies.Any(e => e.Id == id);
        }
    }
}
