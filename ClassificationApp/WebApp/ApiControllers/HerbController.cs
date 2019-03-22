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
    public class HerbController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HerbController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Herb
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Herb>>> GetHerbs()
        {
            return await _context.Herbs.ToListAsync();
        }

        // GET: api/Herb/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Herb>> GetHerb(int id)
        {
            var herb = await _context.Herbs.FindAsync(id);

            if (herb == null)
            {
                return NotFound();
            }

            return herb;
        }

        // PUT: api/Herb/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerb(int id, Herb herb)
        {
            if (id != herb.Id)
            {
                return BadRequest();
            }

            _context.Entry(herb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerbExists(id))
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

        // POST: api/Herb
        [HttpPost]
        public async Task<ActionResult<Herb>> PostHerb(Herb herb)
        {
            _context.Herbs.Add(herb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHerb", new { id = herb.Id }, herb);
        }

        // DELETE: api/Herb/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Herb>> DeleteHerb(int id)
        {
            var herb = await _context.Herbs.FindAsync(id);
            if (herb == null)
            {
                return NotFound();
            }

            _context.Herbs.Remove(herb);
            await _context.SaveChangesAsync();

            return herb;
        }

        private bool HerbExists(int id)
        {
            return _context.Herbs.Any(e => e.Id == id);
        }
    }
}
