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
    public class PlantPartController : Controller
    {
        private readonly AppDbContext _context;

        public PlantPartController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PlantPart
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlantParts.ToListAsync());
        }

        // GET: PlantPart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantPart = await _context.PlantParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantPart == null)
            {
                return NotFound();
            }

            return View(plantPart);
        }

        // GET: PlantPart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantPart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantPartValueLatin,PlantPartValueEstonian,PlantPartValueEnglish,Id")] PlantPart plantPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantPart);
        }

        // GET: PlantPart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantPart = await _context.PlantParts.FindAsync(id);
            if (plantPart == null)
            {
                return NotFound();
            }
            return View(plantPart);
        }

        // POST: PlantPart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantPartValueLatin,PlantPartValueEstonian,PlantPartValueEnglish,Id")] PlantPart plantPart)
        {
            if (id != plantPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantPartExists(plantPart.Id))
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
            return View(plantPart);
        }

        // GET: PlantPart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantPart = await _context.PlantParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantPart == null)
            {
                return NotFound();
            }

            return View(plantPart);
        }

        // POST: PlantPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantPart = await _context.PlantParts.FindAsync(id);
            _context.PlantParts.Remove(plantPart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantPartExists(int id)
        {
            return _context.PlantParts.Any(e => e.Id == id);
        }
    }
}
