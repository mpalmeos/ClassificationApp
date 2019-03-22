using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRoleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompanyRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyRole>>> GetCompanyRoles()
        {
            return await _context.CompanyRoles.ToListAsync();
        }

        // GET: api/CompanyRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyRole>> GetCompanyRole(int id)
        {
            var companyRole = await _context.CompanyRoles.FindAsync(id);

            if (companyRole == null)
            {
                return NotFound();
            }

            return companyRole;
        }

        // PUT: api/CompanyRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyRole(int id, CompanyRole companyRole)
        {
            if (id != companyRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CompanyRole
        [HttpPost]
        public async Task<ActionResult<CompanyRole>> PostCompanyRole(CompanyRole companyRole)
        {
            _context.CompanyRoles.Add(companyRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyRole", new { id = companyRole.Id }, companyRole);
        }

        // DELETE: api/CompanyRole/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyRole>> DeleteCompanyRole(int id)
        {
            var companyRole = await _context.CompanyRoles.FindAsync(id);
            if (companyRole == null)
            {
                return NotFound();
            }

            _context.CompanyRoles.Remove(companyRole);
            await _context.SaveChangesAsync();

            return companyRole;
        }

        private bool CompanyRoleExists(int id)
        {
            return _context.CompanyRoles.Any(e => e.Id == id);
        }
    }
}
