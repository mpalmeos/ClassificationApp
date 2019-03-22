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
    public class SubstanceMedicinalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubstanceMedicinalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SubstanceMedicinal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubstanceMedicinal>>> GetSubstanceMedicinals()
        {
            return await _context.SubstanceMedicinals.ToListAsync();
        }

        // GET: api/SubstanceMedicinal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubstanceMedicinal>> GetSubstanceMedicinal(int id)
        {
            var substanceMedicinal = await _context.SubstanceMedicinals.FindAsync(id);

            if (substanceMedicinal == null)
            {
                return NotFound();
            }

            return substanceMedicinal;
        }

        // PUT: api/SubstanceMedicinal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubstanceMedicinal(int id, SubstanceMedicinal substanceMedicinal)
        {
            if (id != substanceMedicinal.Id)
            {
                return BadRequest();
            }

            _context.Entry(substanceMedicinal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstanceMedicinalExists(id))
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

        // POST: api/SubstanceMedicinal
        [HttpPost]
        public async Task<ActionResult<SubstanceMedicinal>> PostSubstanceMedicinal(SubstanceMedicinal substanceMedicinal)
        {
            _context.SubstanceMedicinals.Add(substanceMedicinal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubstanceMedicinal", new { id = substanceMedicinal.Id }, substanceMedicinal);
        }

        // DELETE: api/SubstanceMedicinal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubstanceMedicinal>> DeleteSubstanceMedicinal(int id)
        {
            var substanceMedicinal = await _context.SubstanceMedicinals.FindAsync(id);
            if (substanceMedicinal == null)
            {
                return NotFound();
            }

            _context.SubstanceMedicinals.Remove(substanceMedicinal);
            await _context.SaveChangesAsync();

            return substanceMedicinal;
        }

        private bool SubstanceMedicinalExists(int id)
        {
            return _context.SubstanceMedicinals.Any(e => e.Id == id);
        }
    }
}
