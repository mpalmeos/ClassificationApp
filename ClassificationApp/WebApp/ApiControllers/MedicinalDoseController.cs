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
    public class MedicinalDoseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicinalDoseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicinalDose
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicinalDose>>> GetMedicinalDoses()
        {
            return await _context.MedicinalDoses.ToListAsync();
        }

        // GET: api/MedicinalDose/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicinalDose>> GetMedicinalDose(int id)
        {
            var medicinalDose = await _context.MedicinalDoses.FindAsync(id);

            if (medicinalDose == null)
            {
                return NotFound();
            }

            return medicinalDose;
        }

        // PUT: api/MedicinalDose/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicinalDose(int id, MedicinalDose medicinalDose)
        {
            if (id != medicinalDose.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicinalDose).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicinalDoseExists(id))
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

        // POST: api/MedicinalDose
        [HttpPost]
        public async Task<ActionResult<MedicinalDose>> PostMedicinalDose(MedicinalDose medicinalDose)
        {
            _context.MedicinalDoses.Add(medicinalDose);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicinalDose", new { id = medicinalDose.Id }, medicinalDose);
        }

        // DELETE: api/MedicinalDose/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicinalDose>> DeleteMedicinalDose(int id)
        {
            var medicinalDose = await _context.MedicinalDoses.FindAsync(id);
            if (medicinalDose == null)
            {
                return NotFound();
            }

            _context.MedicinalDoses.Remove(medicinalDose);
            await _context.SaveChangesAsync();

            return medicinalDose;
        }

        private bool MedicinalDoseExists(int id)
        {
            return _context.MedicinalDoses.Any(e => e.Id == id);
        }
    }
}
