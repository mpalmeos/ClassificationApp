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
    public class SubstanceController : Controller
    {
        private readonly AppDbContext _context;

        public SubstanceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Substance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Substances.ToListAsync());
        }

        // GET: Substance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substance = await _context.Substances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (substance == null)
            {
                return NotFound();
            }

            return View(substance);
        }

        // GET: Substance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Substance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstanceName,Id")] Substance substance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(substance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(substance);
        }

        // GET: Substance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substance = await _context.Substances.FindAsync(id);
            if (substance == null)
            {
                return NotFound();
            }
            return View(substance);
        }

        // POST: Substance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubstanceName,Id")] Substance substance)
        {
            if (id != substance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(substance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubstanceExists(substance.Id))
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
            return View(substance);
        }

        // GET: Substance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substance = await _context.Substances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (substance == null)
            {
                return NotFound();
            }

            return View(substance);
        }

        // POST: Substance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var substance = await _context.Substances.FindAsync(id);
            _context.Substances.Remove(substance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubstanceExists(int id)
        {
            return _context.Substances.Any(e => e.Id == id);
        }
    }
}
