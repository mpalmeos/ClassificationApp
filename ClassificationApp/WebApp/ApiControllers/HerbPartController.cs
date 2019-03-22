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
    public class HerbPartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HerbPartController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HerbPart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbPart>>> GetHerbParts()
        {
            return await _context.HerbParts.ToListAsync();
        }

        // GET: api/HerbPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbPart>> GetHerbPart(int id)
        {
            var herbPart = await _context.HerbParts.FindAsync(id);

            if (herbPart == null)
            {
                return NotFound();
            }

            return herbPart;
        }

        // PUT: api/HerbPart/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerbPart(int id, HerbPart herbPart)
        {
            if (id != herbPart.Id)
            {
                return BadRequest();
            }

            _context.Entry(herbPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerbPartExists(id))
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

        // POST: api/HerbPart
        [HttpPost]
        public async Task<ActionResult<HerbPart>> PostHerbPart(HerbPart herbPart)
        {
            _context.HerbParts.Add(herbPart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHerbPart", new { id = herbPart.Id }, herbPart);
        }

        // DELETE: api/HerbPart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HerbPart>> DeleteHerbPart(int id)
        {
            var herbPart = await _context.HerbParts.FindAsync(id);
            if (herbPart == null)
            {
                return NotFound();
            }

            _context.HerbParts.Remove(herbPart);
            await _context.SaveChangesAsync();

            return herbPart;
        }

        private bool HerbPartExists(int id)
        {
            return _context.HerbParts.Any(e => e.Id == id);
        }
    }
}
