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
    public class HerbController : Controller
    {
        private readonly AppDbContext _context;

        public HerbController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Herb
        public async Task<IActionResult> Index()
        {
            return View(await _context.Herbs.ToListAsync());
        }

        // GET: Herb/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herb = await _context.Herbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herb == null)
            {
                return NotFound();
            }

            return View(herb);
        }

        // GET: Herb/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Herb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HerbNameLatin,HerbNameEstonian,HerbNameEnglish,Id")] Herb herb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(herb);
        }

        // GET: Herb/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herb = await _context.Herbs.FindAsync(id);
            if (herb == null)
            {
                return NotFound();
            }
            return View(herb);
        }

        // POST: Herb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HerbNameLatin,HerbNameEstonian,HerbNameEnglish,Id")] Herb herb)
        {
            if (id != herb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerbExists(herb.Id))
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
            return View(herb);
        }

        // GET: Herb/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herb = await _context.Herbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (herb == null)
            {
                return NotFound();
            }

            return View(herb);
        }

        // POST: Herb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var herb = await _context.Herbs.FindAsync(id);
            _context.Herbs.Remove(herb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerbExists(int id)
        {
            return _context.Herbs.Any(e => e.Id == id);
        }
    }
}
