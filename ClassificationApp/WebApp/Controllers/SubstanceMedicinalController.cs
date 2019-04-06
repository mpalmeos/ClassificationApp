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
    public class SubstanceMedicinalController : Controller
    {
        private readonly AppDbContext _context;

        public SubstanceMedicinalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SubstanceMedicinal
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SubstanceMedicinals.Include(s => s.MedicinalDose).Include(s => s.Substance);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SubstanceMedicinal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substanceMedicinal = await _context.SubstanceMedicinals
                .Include(s => s.MedicinalDose)
                .Include(s => s.Substance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (substanceMedicinal == null)
            {
                return NotFound();
            }

            return View(substanceMedicinal);
        }

        // GET: SubstanceMedicinal/Create
        public IActionResult Create()
        {
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "Id");
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName");
            return View();
        }

        // POST: SubstanceMedicinal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstanceId,MedicinalDoseId,Id")] SubstanceMedicinal substanceMedicinal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(substanceMedicinal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "Id", substanceMedicinal.MedicinalDoseId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", substanceMedicinal.SubstanceId);
            return View(substanceMedicinal);
        }

        // GET: SubstanceMedicinal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substanceMedicinal = await _context.SubstanceMedicinals.FindAsync(id);
            if (substanceMedicinal == null)
            {
                return NotFound();
            }
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "Id", substanceMedicinal.MedicinalDoseId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", substanceMedicinal.SubstanceId);
            return View(substanceMedicinal);
        }

        // POST: SubstanceMedicinal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubstanceId,MedicinalDoseId,Id")] SubstanceMedicinal substanceMedicinal)
        {
            if (id != substanceMedicinal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(substanceMedicinal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubstanceMedicinalExists(substanceMedicinal.Id))
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
            ViewData["MedicinalDoseId"] = new SelectList(_context.MedicinalDoses, "Id", "Id", substanceMedicinal.MedicinalDoseId);
            ViewData["SubstanceId"] = new SelectList(_context.Substances, "Id", "SubstanceName", substanceMedicinal.SubstanceId);
            return View(substanceMedicinal);
        }

        // GET: SubstanceMedicinal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substanceMedicinal = await _context.SubstanceMedicinals
                .Include(s => s.MedicinalDose)
                .Include(s => s.Substance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (substanceMedicinal == null)
            {
                return NotFound();
            }

            return View(substanceMedicinal);
        }

        // POST: SubstanceMedicinal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var substanceMedicinal = await _context.SubstanceMedicinals.FindAsync(id);
            _context.SubstanceMedicinals.Remove(substanceMedicinal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubstanceMedicinalExists(int id)
        {
            return _context.SubstanceMedicinals.Any(e => e.Id == id);
        }
    }
}
