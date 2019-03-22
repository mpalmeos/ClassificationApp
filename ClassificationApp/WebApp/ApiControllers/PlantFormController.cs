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
    public class PlantFormController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlantFormController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PlantForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantForm>>> GetPlantForms()
        {
            return await _context.PlantForms.ToListAsync();
        }

        // GET: api/PlantForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantForm>> GetPlantForm(int id)
        {
            var plantForm = await _context.PlantForms.FindAsync(id);

            if (plantForm == null)
            {
                return NotFound();
            }

            return plantForm;
        }

        // PUT: api/PlantForm/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantForm(int id, PlantForm plantForm)
        {
            if (id != plantForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantFormExists(id))
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

        // POST: api/PlantForm
        [HttpPost]
        public async Task<ActionResult<PlantForm>> PostPlantForm(PlantForm plantForm)
        {
            _context.PlantForms.Add(plantForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantForm", new { id = plantForm.Id }, plantForm);
        }

        // DELETE: api/PlantForm/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantForm>> DeletePlantForm(int id)
        {
            var plantForm = await _context.PlantForms.FindAsync(id);
            if (plantForm == null)
            {
                return NotFound();
            }

            _context.PlantForms.Remove(plantForm);
            await _context.SaveChangesAsync();

            return plantForm;
        }

        private bool PlantFormExists(int id)
        {
            return _context.PlantForms.Any(e => e.Id == id);
        }
    }
}
