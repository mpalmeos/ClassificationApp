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
    public class CompositionSubstanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompositionSubstanceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CompositionSubstance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionSubstance>>> GetCompositionSubstances()
        {
            return await _context.CompositionSubstances.ToListAsync();
        }

        // GET: api/CompositionSubstance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompositionSubstance>> GetCompositionSubstance(int id)
        {
            var compositionSubstance = await _context.CompositionSubstances.FindAsync(id);

            if (compositionSubstance == null)
            {
                return NotFound();
            }

            return compositionSubstance;
        }

        // PUT: api/CompositionSubstance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompositionSubstance(int id, CompositionSubstance compositionSubstance)
        {
            if (id != compositionSubstance.Id)
            {
                return BadRequest();
            }

            _context.Entry(compositionSubstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompositionSubstanceExists(id))
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

        // POST: api/CompositionSubstance
        [HttpPost]
        public async Task<ActionResult<CompositionSubstance>> PostCompositionSubstance(CompositionSubstance compositionSubstance)
        {
            _context.CompositionSubstances.Add(compositionSubstance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompositionSubstance", new { id = compositionSubstance.Id }, compositionSubstance);
        }

        // DELETE: api/CompositionSubstance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompositionSubstance>> DeleteCompositionSubstance(int id)
        {
            var compositionSubstance = await _context.CompositionSubstances.FindAsync(id);
            if (compositionSubstance == null)
            {
                return NotFound();
            }

            _context.CompositionSubstances.Remove(compositionSubstance);
            await _context.SaveChangesAsync();

            return compositionSubstance;
        }

        private bool CompositionSubstanceExists(int id)
        {
            return _context.CompositionSubstances.Any(e => e.Id == id);
        }
    }
}
