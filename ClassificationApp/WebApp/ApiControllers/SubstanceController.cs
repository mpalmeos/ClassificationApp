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
    public class SubstanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubstanceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Substance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Substance>>> GetSubstances()
        {
            return await _context.Substances.ToListAsync();
        }

        // GET: api/Substance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Substance>> GetSubstance(int id)
        {
            var substance = await _context.Substances.FindAsync(id);

            if (substance == null)
            {
                return NotFound();
            }

            return substance;
        }

        // PUT: api/Substance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubstance(int id, Substance substance)
        {
            if (id != substance.Id)
            {
                return BadRequest();
            }

            _context.Entry(substance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstanceExists(id))
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

        // POST: api/Substance
        [HttpPost]
        public async Task<ActionResult<Substance>> PostSubstance(Substance substance)
        {
            _context.Substances.Add(substance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubstance", new { id = substance.Id }, substance);
        }

        // DELETE: api/Substance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Substance>> DeleteSubstance(int id)
        {
            var substance = await _context.Substances.FindAsync(id);
            if (substance == null)
            {
                return NotFound();
            }

            _context.Substances.Remove(substance);
            await _context.SaveChangesAsync();

            return substance;
        }

        private bool SubstanceExists(int id)
        {
            return _context.Substances.Any(e => e.Id == id);
        }
    }
}
