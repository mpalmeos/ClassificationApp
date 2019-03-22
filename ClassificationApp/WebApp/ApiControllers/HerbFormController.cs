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
    public class HerbFormController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HerbFormController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HerbForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HerbForm>>> GetHerbForms()
        {
            return await _context.HerbForms.ToListAsync();
        }

        // GET: api/HerbForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HerbForm>> GetHerbForm(int id)
        {
            var herbForm = await _context.HerbForms.FindAsync(id);

            if (herbForm == null)
            {
                return NotFound();
            }

            return herbForm;
        }

        // PUT: api/HerbForm/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerbForm(int id, HerbForm herbForm)
        {
            if (id != herbForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(herbForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerbFormExists(id))
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

        // POST: api/HerbForm
        [HttpPost]
        public async Task<ActionResult<HerbForm>> PostHerbForm(HerbForm herbForm)
        {
            _context.HerbForms.Add(herbForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHerbForm", new { id = herbForm.Id }, herbForm);
        }

        // DELETE: api/HerbForm/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HerbForm>> DeleteHerbForm(int id)
        {
            var herbForm = await _context.HerbForms.FindAsync(id);
            if (herbForm == null)
            {
                return NotFound();
            }

            _context.HerbForms.Remove(herbForm);
            await _context.SaveChangesAsync();

            return herbForm;
        }

        private bool HerbFormExists(int id)
        {
            return _context.HerbForms.Any(e => e.Id == id);
        }
    }
}
