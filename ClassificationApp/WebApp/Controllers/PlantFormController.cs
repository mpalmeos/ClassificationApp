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
    public class PlantFormController : Controller
    {
        private readonly AppDbContext _context;

        public PlantFormController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PlantForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlantForms.ToListAsync());
        }

        // GET: PlantForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantForm = await _context.PlantForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantForm == null)
            {
                return NotFound();
            }

            return View(plantForm);
        }

        // GET: PlantForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantFormValueLatin,PlantFormValueEstonian,PlantFormValueEnglish,Id")] PlantForm plantForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantForm);
        }

        // GET: PlantForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantForm = await _context.PlantForms.FindAsync(id);
            if (plantForm == null)
            {
                return NotFound();
            }
            return View(plantForm);
        }

        // POST: PlantForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantFormValueLatin,PlantFormValueEstonian,PlantFormValueEnglish,Id")] PlantForm plantForm)
        {
            if (id != plantForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantFormExists(plantForm.Id))
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
            return View(plantForm);
        }

        // GET: PlantForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantForm = await _context.PlantForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantForm == null)
            {
                return NotFound();
            }

            return View(plantForm);
        }

        // POST: PlantForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantForm = await _context.PlantForms.FindAsync(id);
            _context.PlantForms.Remove(plantForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantFormExists(int id)
        {
            return _context.PlantForms.Any(e => e.Id == id);
        }
    }
}
