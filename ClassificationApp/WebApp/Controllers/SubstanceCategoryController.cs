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
    public class SubstanceCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public SubstanceCategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SubstanceCategory
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SubstanceCategories.Include(s => s.Category).Include(s => s.Substance);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SubstanceCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substanceCategory = await _context.SubstanceCategories
                .Include(s => s.Category)
                .Include(s => s.Substance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (substanceCategory == null)
            {
                return NotFound();
            }

            return View(substanceCategory);
        }

        // GET: SubstanceCategory/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryValue");
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName");
            return View();
        }

        // POST: SubstanceCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,SubstanceId,Id")] SubstanceCategory substanceCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(substanceCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryValue", substanceCategory.CategoryId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", substanceCategory.SubstanceId);
            return View(substanceCategory);
        }

        // GET: SubstanceCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substanceCategory = await _context.SubstanceCategories.FindAsync(id);
            if (substanceCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryValue", substanceCategory.CategoryId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", substanceCategory.SubstanceId);
            return View(substanceCategory);
        }

        // POST: SubstanceCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,SubstanceId,Id")] SubstanceCategory substanceCategory)
        {
            if (id != substanceCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(substanceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubstanceCategoryExists(substanceCategory.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryValue", substanceCategory.CategoryId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", substanceCategory.SubstanceId);
            return View(substanceCategory);
        }

        // GET: SubstanceCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substanceCategory = await _context.SubstanceCategories
                .Include(s => s.Category)
                .Include(s => s.Substance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (substanceCategory == null)
            {
                return NotFound();
            }

            return View(substanceCategory);
        }

        // POST: SubstanceCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var substanceCategory = await _context.SubstanceCategories.FindAsync(id);
            _context.SubstanceCategories.Remove(substanceCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubstanceCategoryExists(int id)
        {
            return _context.SubstanceCategories.Any(e => e.Id == id);
        }
    }
}
