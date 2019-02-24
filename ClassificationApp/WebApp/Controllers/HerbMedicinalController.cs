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
    public class HerbMedicinalController : Controller
    {
        private readonly AppDbContext _context;

        public HerbMedicinalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HerbMedicinal
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HerbMedicinals.Include(h => h.Herb).Include(h => h.HerbForm).Include(h => h.HerbPart).Include(h => h.MedicinalDose);
            return View(await appDbContext.ToListAsync());
        }

        // GET: HerbMedicinal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbMedicinal = await _context.HerbMedicinals
                .Include(h => h.Herb)
                .Include(h => h.HerbForm)
                .Include(h => h.HerbPart)
                .Include(h => h.MedicinalDose)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herbMedicinal == null)
            {
                return NotFound();
            }

            return View(herbMedicinal);
        }

        // GET: HerbMedicinal/Create
        public IActionResult Create()
        {
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin");
            ViewData["HerbFormId"] = new SelectList(_context.HerbForms, "Id", "Id");
            ViewData["HerbPartId"] = new SelectList(_context.HerbParts, "Id", "Id");
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "MedicinalDoseValue");
            return View();
        }

        // POST: HerbMedicinal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HerbId,MedicinalDoseId,HerbPartId,HerbFormId,Id")] HerbMedicinal herbMedicinal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herbMedicinal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbMedicinal.HerbId);
            ViewData["HerbFormId"] = new SelectList(_context.HerbForms, "Id", "Id", herbMedicinal.HerbFormId);
            ViewData["HerbPartId"] = new SelectList(_context.HerbParts, "Id", "Id", herbMedicinal.HerbPartId);
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "MedicinalDoseValue", herbMedicinal.MedicinalDoseId);
            return View(herbMedicinal);
        }

        // GET: HerbMedicinal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbMedicinal = await _context.HerbMedicinals.FindAsync(id);
            if (herbMedicinal == null)
            {
                return NotFound();
            }
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbMedicinal.HerbId);
            ViewData["HerbFormId"] = new SelectList(_context.HerbForms, "Id", "Id", herbMedicinal.HerbFormId);
            ViewData["HerbPartId"] = new SelectList(_context.HerbParts, "Id", "Id", herbMedicinal.HerbPartId);
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "MedicinalDoseValue", herbMedicinal.MedicinalDoseId);
            return View(herbMedicinal);
        }

        // POST: HerbMedicinal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HerbId,MedicinalDoseId,HerbPartId,HerbFormId,Id")] HerbMedicinal herbMedicinal)
        {
            if (id != herbMedicinal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herbMedicinal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerbMedicinalExists(herbMedicinal.Id))
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
            ViewData["HerbId"] = new SelectList(_context.Herbs, "Id", "HerbNameLatin", herbMedicinal.HerbId);
            ViewData["HerbFormId"] = new SelectList(_context.HerbForms, "Id", "Id", herbMedicinal.HerbFormId);
            ViewData["HerbPartId"] = new SelectList(_context.HerbParts, "Id", "Id", herbMedicinal.HerbPartId);
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "MedicinalDoseValue", herbMedicinal.MedicinalDoseId);
            return View(herbMedicinal);
        }

        // GET: HerbMedicinal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbMedicinal = await _context.HerbMedicinals
                .Include(h => h.Herb)
                .Include(h => h.HerbForm)
                .Include(h => h.HerbPart)
                .Include(h => h.MedicinalDose)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herbMedicinal == null)
            {
                return NotFound();
            }

            return View(herbMedicinal);
        }

        // POST: HerbMedicinal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var herbMedicinal = await _context.HerbMedicinals.FindAsync(id);
            _context.HerbMedicinals.Remove(herbMedicinal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerbMedicinalExists(int id)
        {
            return _context.HerbMedicinals.Any(e => e.Id == id);
        }
    }
}
