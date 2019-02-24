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
    public class MedicinalDoseController : Controller
    {
        private readonly AppDbContext _context;

        public MedicinalDoseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MedicinalDose
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MedicinalDoses.Include(m => m.UnitOfMeasure);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MedicinalDose/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicinalDose = await _context.MedicinalDoses
                .Include(m => m.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicinalDose == null)
            {
                return NotFound();
            }

            return View(medicinalDose);
        }

        // GET: MedicinalDose/Create
        public IActionResult Create()
        {
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue");
            return View();
        }

        // POST: MedicinalDose/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicinalDoseValue,UnitOfMeasureId,Id")] MedicinalDose medicinalDose)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicinalDose);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", medicinalDose.UnitOfMeasureId);
            return View(medicinalDose);
        }

        // GET: MedicinalDose/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicinalDose = await _context.MedicinalDoses.FindAsync(id);
            if (medicinalDose == null)
            {
                return NotFound();
            }
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", medicinalDose.UnitOfMeasureId);
            return View(medicinalDose);
        }

        // POST: MedicinalDose/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicinalDoseValue,UnitOfMeasureId,Id")] MedicinalDose medicinalDose)
        {
            if (id != medicinalDose.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicinalDose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicinalDoseExists(medicinalDose.Id))
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
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitOfMeasures, "Id", "UnitOfMeasureValue", medicinalDose.UnitOfMeasureId);
            return View(medicinalDose);
        }

        // GET: MedicinalDose/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicinalDose = await _context.MedicinalDoses
                .Include(m => m.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicinalDose == null)
            {
                return NotFound();
            }

            return View(medicinalDose);
        }

        // POST: MedicinalDose/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicinalDose = await _context.MedicinalDoses.FindAsync(id);
            _context.MedicinalDoses.Remove(medicinalDose);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicinalDoseExists(int id)
        {
            return _context.MedicinalDoses.Any(e => e.Id == id);
        }
    }
}
