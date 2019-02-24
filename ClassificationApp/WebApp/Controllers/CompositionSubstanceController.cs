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
    public class CompositionSubstanceController : Controller
    {
        private readonly AppDbContext _context;

        public CompositionSubstanceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CompositionSubstance
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CompositionSubstances.Include(c => c.Composition).Include(c => c.Substance).Include(c => c.UnitOfMeasure);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CompositionSubstance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compositionSubstance = await _context.CompositionSubstances
                .Include(c => c.Composition)
                .Include(c => c.Substance)
                .Include(c => c.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compositionSubstance == null)
            {
                return NotFound();
            }

            return View(compositionSubstance);
        }

        // GET: CompositionSubstance/Create
        public IActionResult Create()
        {
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id");
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName");
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue");
            return View();
        }

        // POST: CompositionSubstance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstanceId,CompositionId,UnitOfMeasureId,Id")] CompositionSubstance compositionSubstance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compositionSubstance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", compositionSubstance.CompositionId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", compositionSubstance.SubstanceId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", compositionSubstance.UnitOfMeasureId);
            return View(compositionSubstance);
        }

        // GET: CompositionSubstance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compositionSubstance = await _context.CompositionSubstances.FindAsync(id);
            if (compositionSubstance == null)
            {
                return NotFound();
            }
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", compositionSubstance.CompositionId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", compositionSubstance.SubstanceId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", compositionSubstance.UnitOfMeasureId);
            return View(compositionSubstance);
        }

        // POST: CompositionSubstance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubstanceId,CompositionId,UnitOfMeasureId,Id")] CompositionSubstance compositionSubstance)
        {
            if (id != compositionSubstance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compositionSubstance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompositionSubstanceExists(compositionSubstance.Id))
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
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", compositionSubstance.CompositionId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", compositionSubstance.SubstanceId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", compositionSubstance.UnitOfMeasureId);
            return View(compositionSubstance);
        }

        // GET: CompositionSubstance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compositionSubstance = await _context.CompositionSubstances
                .Include(c => c.Composition)
                .Include(c => c.Substance)
                .Include(c => c.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compositionSubstance == null)
            {
                return NotFound();
            }

            return View(compositionSubstance);
        }

        // POST: CompositionSubstance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compositionSubstance = await _context.CompositionSubstances.FindAsync(id);
            _context.CompositionSubstances.Remove(compositionSubstance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompositionSubstanceExists(int id)
        {
            return _context.CompositionSubstances.Any(e => e.Id == id);
        }
    }
}
