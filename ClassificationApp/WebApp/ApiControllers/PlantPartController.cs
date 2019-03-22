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
    public class PlantPartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlantPartController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PlantPart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantPart>>> GetPlantParts()
        {
            return await _context.PlantParts.ToListAsync();
        }

        // GET: api/PlantPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantPart>> GetPlantPart(int id)
        {
            var plantPart = await _context.PlantParts.FindAsync(id);

            if (plantPart == null)
            {
                return NotFound();
            }

            return plantPart;
        }

        // PUT: api/PlantPart/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantPart(int id, PlantPart plantPart)
        {
            if (id != plantPart.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantPartExists(id))
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

        // POST: api/PlantPart
        [HttpPost]
        public async Task<ActionResult<PlantPart>> PostPlantPart(PlantPart plantPart)
        {
            _context.PlantParts.Add(plantPart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantPart", new { id = plantPart.Id }, plantPart);
        }

        // DELETE: api/PlantPart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantPart>> DeletePlantPart(int id)
        {
            var plantPart = await _context.PlantParts.FindAsync(id);
            if (plantPart == null)
            {
                return NotFound();
            }

            _context.PlantParts.Remove(plantPart);
            await _context.SaveChangesAsync();

            return plantPart;
        }

        private bool PlantPartExists(int id)
        {
            return _context.PlantParts.Any(e => e.Id == id);
        }
    }
}
