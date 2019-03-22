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
    public class CRoleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CRoleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CRole>>> GetCRoles()
        {
            return await _context.CRoles.ToListAsync();
        }

        // GET: api/CRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CRole>> GetCRole(int id)
        {
            var cRole = await _context.CRoles.FindAsync(id);

            if (cRole == null)
            {
                return NotFound();
            }

            return cRole;
        }

        // PUT: api/CRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCRole(int id, CRole cRole)
        {
            if (id != cRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(cRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CRoleExists(id))
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

        // POST: api/CRole
        [HttpPost]
        public async Task<ActionResult<CRole>> PostCRole(CRole cRole)
        {
            _context.CRoles.Add(cRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCRole", new { id = cRole.Id }, cRole);
        }

        // DELETE: api/CRole/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CRole>> DeleteCRole(int id)
        {
            var cRole = await _context.CRoles.FindAsync(id);
            if (cRole == null)
            {
                return NotFound();
            }

            _context.CRoles.Remove(cRole);
            await _context.SaveChangesAsync();

            return cRole;
        }

        private bool CRoleExists(int id)
        {
            return _context.CRoles.Any(e => e.Id == id);
        }
    }
}
