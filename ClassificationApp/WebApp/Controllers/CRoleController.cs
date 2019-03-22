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
    public class CRoleController : Controller
    {
        private readonly AppDbContext _context;

        public CRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.CRoles.ToListAsync());
        }

        // GET: CRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRole = await _context.CRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cRole == null)
            {
                return NotFound();
            }

            return View(cRole);
        }

        // GET: CRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleValue,Id")] CRole cRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cRole);
        }

        // GET: CRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRole = await _context.CRoles.FindAsync(id);
            if (cRole == null)
            {
                return NotFound();
            }
            return View(cRole);
        }

        // POST: CRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleValue,Id")] CRole cRole)
        {
            if (id != cRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CRoleExists(cRole.Id))
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
            return View(cRole);
        }

        // GET: CRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRole = await _context.CRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cRole == null)
            {
                return NotFound();
            }

            return View(cRole);
        }

        // POST: CRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cRole = await _context.CRoles.FindAsync(id);
            _context.CRoles.Remove(cRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CRoleExists(int id)
        {
            return _context.CRoles.Any(e => e.Id == id);
        }
    }
}
