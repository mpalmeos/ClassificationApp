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
    public class HerbMedicinalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HerbMedicinalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HerbMedicinal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbMedicinal>>> GetHerbMedicinals()
        {
            return await _context.HerbMedicinals.ToListAsync();
        }

        // GET: api/HerbMedicinal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbMedicinal>> GetHerbMedicinal(int id)
        {
            var herbMedicinal = await _context.HerbMedicinals.FindAsync(id);

            if (herbMedicinal == null)
            {
                return NotFound();
            }

            return herbMedicinal;
        }

        // PUT: api/HerbMedicinal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerbMedicinal(int id, HerbMedicinal herbMedicinal)
        {
            if (id != herbMedicinal.Id)
            {
                return BadRequest();
            }

            _context.Entry(herbMedicinal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerbMedicinalExists(id))
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

        // POST: api/HerbMedicinal
        [HttpPost]
        public async Task<ActionResult<HerbMedicinal>> PostHerbMedicinal(HerbMedicinal herbMedicinal)
        {
            _context.HerbMedicinals.Add(herbMedicinal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHerbMedicinal", new { id = herbMedicinal.Id }, herbMedicinal);
        }

        // DELETE: api/HerbMedicinal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HerbMedicinal>> DeleteHerbMedicinal(int id)
        {
            var herbMedicinal = await _context.HerbMedicinals.FindAsync(id);
            if (herbMedicinal == null)
            {
                return NotFound();
            }

            _context.HerbMedicinals.Remove(herbMedicinal);
            await _context.SaveChangesAsync();

            return herbMedicinal;
        }

        private bool HerbMedicinalExists(int id)
        {
            return _context.HerbMedicinals.Any(e => e.Id == id);
        }
    }
}
