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
    public class HerbPartController : Controller
    {
        private readonly AppDbContext _context;

        public HerbPartController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HerbPart
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HerbParts.Include(h => h.Herb).Include(h => h.PlantPart);
            return View(await appDbContext.ToListAsync());
        }

        // GET: HerbPart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbPart = await _context.HerbParts
                .Include(h => h.Herb)
                .Include(h => h.PlantPart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herbPart == null)
            {
                return NotFound();
            }

            return View(herbPart);
        }

        // GET: HerbPart/Create
        public IActionResult Create()
        {
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin");
            ViewData["PlantPartId"] = new SelectList(_context.PlantParts, "Id", "PlantPartValueLatin");
            return View();
        }

        // POST: HerbPart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HerbId,PlantPartId,Id")] HerbPart herbPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herbPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbPart.HerbId);
            ViewData["PlantPartId"] = new SelectList(_context.PlantParts, "Id", "PlantPartValueLatin", herbPart.PlantPartId);
            return View(herbPart);
        }

        // GET: HerbPart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbPart = await _context.HerbParts.FindAsync(id);
            if (herbPart == null)
            {
                return NotFound();
            }
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbPart.HerbId);
            ViewData["PlantPartId"] = new SelectList(_context.PlantParts, "Id", "PlantPartValueLatin", herbPart.PlantPartId);
            return View(herbPart);
        }

        // POST: HerbPart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HerbId,PlantPartId,Id")] HerbPart herbPart)
        {
            if (id != herbPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herbPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerbPartExists(herbPart.Id))
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
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbPart.HerbId);
            ViewData["PlantPartId"] = new SelectList(_context.PlantParts, "Id", "PlantPartValueLatin", herbPart.PlantPartId);
            return View(herbPart);
        }

        // GET: HerbPart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbPart = await _context.HerbParts
                .Include(h => h.Herb)
                .Include(h => h.PlantPart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herbPart == null)
            {
                return NotFound();
            }

            return View(herbPart);
        }

        // POST: HerbPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var herbPart = await _context.HerbParts.FindAsync(id);
            _context.HerbParts.Remove(herbPart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerbPartExists(int id)
        {
            return _context.HerbParts.Any(e => e.Id == id);
        }
    }
}
