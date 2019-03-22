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
    public class DosageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DosageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Dosage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dosage>>> GetDosages()
        {
            return await _context.Dosages.ToListAsync();
        }

        // GET: api/Dosage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dosage>> GetDosage(int id)
        {
            var dosage = await _context.Dosages.FindAsync(id);

            if (dosage == null)
            {
                return NotFound();
            }

            return dosage;
        }

        // PUT: api/Dosage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDosage(int id, Dosage dosage)
        {
            if (id != dosage.Id)
            {
                return BadRequest();
            }

            _context.Entry(dosage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DosageExists(id))
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

        // POST: api/Dosage
        [HttpPost]
        public async Task<ActionResult<Dosage>> PostDosage(Dosage dosage)
        {
            _context.Dosages.Add(dosage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDosage", new { id = dosage.Id }, dosage);
        }

        // DELETE: api/Dosage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dosage>> DeleteDosage(int id)
        {
            var dosage = await _context.Dosages.FindAsync(id);
            if (dosage == null)
            {
                return NotFound();
            }

            _context.Dosages.Remove(dosage);
            await _context.SaveChangesAsync();

            return dosage;
        }

        private bool DosageExists(int id)
        {
            return _context.Dosages.Any(e => e.Id == id);
        }
    }
}
