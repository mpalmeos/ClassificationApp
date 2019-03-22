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
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UnitOfMeasureController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UnitOfMeasure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasure>>> GetUnitOfMeasures()
        {
            return await _context.UnitOfMeasures.ToListAsync();
        }

        // GET: api/UnitOfMeasure/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasure>> GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _context.UnitOfMeasures.FindAsync(id);

            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return unitOfMeasure;
        }

        // PUT: api/UnitOfMeasure/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitOfMeasure(int id, UnitOfMeasure unitOfMeasure)
        {
            if (id != unitOfMeasure.Id)
            {
                return BadRequest();
            }

            _context.Entry(unitOfMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitOfMeasureExists(id))
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

        // POST: api/UnitOfMeasure
        [HttpPost]
        public async Task<ActionResult<UnitOfMeasure>> PostUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            _context.UnitOfMeasures.Add(unitOfMeasure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnitOfMeasure", new { id = unitOfMeasure.Id }, unitOfMeasure);
        }

        // DELETE: api/UnitOfMeasure/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnitOfMeasure>> DeleteUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _context.UnitOfMeasures.FindAsync(id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            _context.UnitOfMeasures.Remove(unitOfMeasure);
            await _context.SaveChangesAsync();

            return unitOfMeasure;
        }

        private bool UnitOfMeasureExists(int id)
        {
            return _context.UnitOfMeasures.Any(e => e.Id == id);
        }
    }
}
