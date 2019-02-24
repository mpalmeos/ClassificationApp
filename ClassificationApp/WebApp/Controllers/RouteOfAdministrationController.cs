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
    public class RouteOfAdministrationController : Controller
    {
        private readonly AppDbContext _context;

        public RouteOfAdministrationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RouteOfAdministration
        public async Task<IActionResult> Index()
        {
            return View(await _context.RouteOfAdministrations.ToListAsync());
        }

        // GET: RouteOfAdministration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeOfAdministration = await _context.RouteOfAdministrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            return View(routeOfAdministration);
        }

        // GET: RouteOfAdministration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RouteOfAdministration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteOfAdministrationValue,Id")] RouteOfAdministration routeOfAdministration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routeOfAdministration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routeOfAdministration);
        }

        // GET: RouteOfAdministration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeOfAdministration = await _context.RouteOfAdministrations.FindAsync(id);
            if (routeOfAdministration == null)
            {
                return NotFound();
            }
            return View(routeOfAdministration);
        }

        // POST: RouteOfAdministration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouteOfAdministrationValue,Id")] RouteOfAdministration routeOfAdministration)
        {
            if (id != routeOfAdministration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routeOfAdministration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteOfAdministrationExists(routeOfAdministration.Id))
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
            return View(routeOfAdministration);
        }

        // GET: RouteOfAdministration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeOfAdministration = await _context.RouteOfAdministrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routeOfAdministration == null)
            {
                return NotFound();
            }

            return View(routeOfAdministration);
        }

        // POST: RouteOfAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routeOfAdministration = await _context.RouteOfAdministrations.FindAsync(id);
            _context.RouteOfAdministrations.Remove(routeOfAdministration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteOfAdministrationExists(int id)
        {
            return _context.RouteOfAdministrations.Any(e => e.Id == id);
        }
    }
}
