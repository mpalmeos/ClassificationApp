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
    public class CompositionHerbController : Controller
    {
        private readonly AppDbContext _context;

        public CompositionHerbController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CompositionHerb
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CompositionHerbs.Include(c => c.Composition).Include(c => c.Herb).Include(c => c.UnitOfMeasure);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CompositionHerb/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compositionHerb = await _context.CompositionHerbs
                .Include(c => c.Composition)
                .Include(c => c.Herb)
                .Include(c => c.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compositionHerb == null)
            {
                return NotFound();
            }

            return View(compositionHerb);
        }

        // GET: CompositionHerb/Create
        public IActionResult Create()
        {
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id");
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin");
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue");
            return View();
        }

        // POST: CompositionHerb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HerbId,CompositionId,UnitOfMeasureId,Id")] CompositionHerb compositionHerb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compositionHerb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", compositionHerb.CompositionId);
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", compositionHerb.HerbId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", compositionHerb.UnitOfMeasureId);
            return View(compositionHerb);
        }

        // GET: CompositionHerb/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compositionHerb = await _context.CompositionHerbs.FindAsync(id);
            if (compositionHerb == null)
            {
                return NotFound();
            }
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", compositionHerb.CompositionId);
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", compositionHerb.HerbId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", compositionHerb.UnitOfMeasureId);
            return View(compositionHerb);
        }

        // POST: CompositionHerb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HerbId,CompositionId,UnitOfMeasureId,Id")] CompositionHerb compositionHerb)
        {
            if (id != compositionHerb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compositionHerb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompositionHerbExists(compositionHerb.Id))
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
            ViewData["CompositionId"] = new SelectList(_context.Compositions, "Id", "Id", compositionHerb.CompositionId);
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", compositionHerb.HerbId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", compositionHerb.UnitOfMeasureId);
            return View(compositionHerb);
        }

        // GET: CompositionHerb/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compositionHerb = await _context.CompositionHerbs
                .Include(c => c.Composition)
                .Include(c => c.Herb)
                .Include(c => c.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compositionHerb == null)
            {
                return NotFound();
            }

            return View(compositionHerb);
        }

        // POST: CompositionHerb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compositionHerb = await _context.CompositionHerbs.FindAsync(id);
            _context.CompositionHerbs.Remove(compositionHerb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompositionHerbExists(int id)
        {
            return _context.CompositionHerbs.Any(e => e.Id == id);
        }
    }
}
