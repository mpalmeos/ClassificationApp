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
    public class HerbFormController : Controller
    {
        private readonly AppDbContext _context;

        public HerbFormController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HerbForm
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HerbForms.Include(h => h.Herb).Include(h => h.PlantForm);
            return View(await appDbContext.ToListAsync());
        }

        // GET: HerbForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbForm = await _context.HerbForms
                .Include(h => h.Herb)
                .Include(h => h.PlantForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herbForm == null)
            {
                return NotFound();
            }

            return View(herbForm);
        }

        // GET: HerbForm/Create
        public IActionResult Create()
        {
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin");
            ViewData["PlantFormId"] = new SelectList(_context.PlantForms, "Id", "PlantFormValueLatin");
            return View();
        }

        // POST: HerbForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HerbId,PlantFormId,Id")] HerbForm herbForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herbForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbForm.HerbId);
            ViewData["PlantFormId"] = new SelectList(_context.PlantForms, "Id", "PlantFormValueLatin", herbForm.PlantFormId);
            return View(herbForm);
        }

        // GET: HerbForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbForm = await _context.HerbForms.FindAsync(id);
            if (herbForm == null)
            {
                return NotFound();
            }
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbForm.HerbId);
            ViewData["PlantFormId"] = new SelectList(_context.PlantForms, "Id", "PlantFormValueLatin", herbForm.PlantFormId);
            return View(herbForm);
        }

        // POST: HerbForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HerbId,PlantFormId,Id")] HerbForm herbForm)
        {
            if (id != herbForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herbForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerbFormExists(herbForm.Id))
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
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbForm.HerbId);
            ViewData["PlantFormId"] = new SelectList(_context.PlantForms, "Id", "PlantFormValueLatin", herbForm.PlantFormId);
            return View(herbForm);
        }

        // GET: HerbForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbForm = await _context.HerbForms
                .Include(h => h.Herb)
                .Include(h => h.PlantForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herbForm == null)
            {
                return NotFound();
            }

            return View(herbForm);
        }

        // POST: HerbForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var herbForm = await _context.HerbForms.FindAsync(id);
            _context.HerbForms.Remove(herbForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerbFormExists(int id)
        {
            return _context.HerbForms.Any(e => e.Id == id);
        }
    }
}
