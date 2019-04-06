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
    public class DosageController : Controller
    {
        private readonly AppDbContext _context;

        public DosageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dosage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dosages.ToListAsync());
        }

        // GET: Dosage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosage = await _context.Dosages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dosage == null)
            {
                return NotFound();
            }

            return View(dosage);
        }

        // GET: Dosage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dosage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosageValue,Id")] Dosage dosage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dosage);
        }

        // GET: Dosage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosage = await _context.Dosages.FindAsync(id);
            if (dosage == null)
            {
                return NotFound();
            }
            return View(dosage);
        }

        // POST: Dosage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosageValue,Id")] Dosage dosage)
        {
            if (id != dosage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosageExists(dosage.Id))
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
            return View(dosage);
        }

        // GET: Dosage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosage = await _context.Dosages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dosage == null)
            {
                return NotFound();
            }

            return View(dosage);
        }

        // POST: Dosage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosage = await _context.Dosages.FindAsync(id);
            _context.Dosages.Remove(dosage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosageExists(int id)
        {
            return _context.Dosages.Any(e => e.Id == id);
        }
    }
}
