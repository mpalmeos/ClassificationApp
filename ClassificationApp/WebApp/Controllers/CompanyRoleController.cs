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
    public class CompanyRoleController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CompanyRole
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CompanyRoles.Include(c => c.CRole).Include(c => c.Company);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CompanyRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRoles
                .Include(c => c.CRole)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyRole == null)
            {
                return NotFound();
            }

            return View(companyRole);
        }

        // GET: CompanyRole/Create
        public IActionResult Create()
        {
            ViewData["CRoleId"] = new SelectList(_context.CRoles, "Id", "RoleValue");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName");
            return View();
        }

        // POST: CompanyRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CRoleId,Id")] CompanyRole companyRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CRoleId"] = new SelectList(_context.CRoles, "Id", "RoleValue", companyRole.CRoleId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", companyRole.CompanyId);
            return View(companyRole);
        }

        // GET: CompanyRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRoles.FindAsync(id);
            if (companyRole == null)
            {
                return NotFound();
            }
            ViewData["CRoleId"] = new SelectList(_context.CRoles, "Id", "RoleValue", companyRole.CRoleId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", companyRole.CompanyId);
            return View(companyRole);
        }

        // POST: CompanyRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CRoleId,Id")] CompanyRole companyRole)
        {
            if (id != companyRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyRoleExists(companyRole.Id))
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
            ViewData["CRoleId"] = new SelectList(_context.CRoles, "Id", "RoleValue", companyRole.CRoleId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", companyRole.CompanyId);
            return View(companyRole);
        }

        // GET: CompanyRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRoles
                .Include(c => c.CRole)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyRole == null)
            {
                return NotFound();
            }

            return View(companyRole);
        }

        // POST: CompanyRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyRole = await _context.CompanyRoles.FindAsync(id);
            _context.CompanyRoles.Remove(companyRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyRoleExists(int id)
        {
            return _context.CompanyRoles.Any(e => e.Id == id);
        }
    }
}
