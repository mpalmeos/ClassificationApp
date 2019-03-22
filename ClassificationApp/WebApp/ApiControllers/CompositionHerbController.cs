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
    public class CompositionHerbController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompositionHerbController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CompositionHerb
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionHerb>>> GetCompositionHerbs()
        {
            return await _context.CompositionHerbs.ToListAsync();
        }

        // GET: api/CompositionHerb/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompositionHerb>> GetCompositionHerb(int id)
        {
            var compositionHerb = await _context.CompositionHerbs.FindAsync(id);

            if (compositionHerb == null)
            {
                return NotFound();
            }

            return compositionHerb;
        }

        // PUT: api/CompositionHerb/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompositionHerb(int id, CompositionHerb compositionHerb)
        {
            if (id != compositionHerb.Id)
            {
                return BadRequest();
            }

            _context.Entry(compositionHerb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompositionHerbExists(id))
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

        // POST: api/CompositionHerb
        [HttpPost]
        public async Task<ActionResult<CompositionHerb>> PostCompositionHerb(CompositionHerb compositionHerb)
        {
            _context.CompositionHerbs.Add(compositionHerb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompositionHerb", new { id = compositionHerb.Id }, compositionHerb);
        }

        // DELETE: api/CompositionHerb/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompositionHerb>> DeleteCompositionHerb(int id)
        {
            var compositionHerb = await _context.CompositionHerbs.FindAsync(id);
            if (compositionHerb == null)
            {
                return NotFound();
            }

            _context.CompositionHerbs.Remove(compositionHerb);
            await _context.SaveChangesAsync();

            return compositionHerb;
        }

        private bool CompositionHerbExists(int id)
        {
            return _context.CompositionHerbs.Any(e => e.Id == id);
        }
    }
}
