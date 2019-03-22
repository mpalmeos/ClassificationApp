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
    public class CompositionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompositionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Composition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composition>>> GetCompositions()
        {
            return await _context.Compositions.ToListAsync();
        }

        // GET: api/Composition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Composition>> GetComposition(int id)
        {
            var composition = await _context.Compositions.FindAsync(id);

            if (composition == null)
            {
                return NotFound();
            }

            return composition;
        }

        // PUT: api/Composition/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComposition(int id, Composition composition)
        {
            if (id != composition.Id)
            {
                return BadRequest();
            }

            _context.Entry(composition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompositionExists(id))
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

        // POST: api/Composition
        [HttpPost]
        public async Task<ActionResult<Composition>> PostComposition(Composition composition)
        {
            _context.Compositions.Add(composition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComposition", new { id = composition.Id }, composition);
        }

        // DELETE: api/Composition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Composition>> DeleteComposition(int id)
        {
            var composition = await _context.Compositions.FindAsync(id);
            if (composition == null)
            {
                return NotFound();
            }

            _context.Compositions.Remove(composition);
            await _context.SaveChangesAsync();

            return composition;
        }

        private bool CompositionExists(int id)
        {
            return _context.Compositions.Any(e => e.Id == id);
        }
    }
}
